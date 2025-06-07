using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailNotificationService.ComViolacao;

internal class EmailNotificationService
{
    public void SendEmail(string provider, string to, string message)
    {
        if (provider == "SMTP")
        {
            var smtServer = "smtp.example.com";
            var userName = string.Empty;
            var password = string.Empty;

            if (string.IsNullOrEmpty(smtServer) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("SMTP configuration is incomplete.");
            }

            Console.WriteLine($"SMT: sending email to {to}");
            Console.WriteLine($"SMTP Config: Server={smtServer}, User={userName}");
        }
        else if (provider == "SES")
        {
            var awsRegion = "us-west-2";
            var accessKey = string.Empty;
            var secretKey = string.Empty;

            if (string.IsNullOrEmpty(awsRegion) || string.IsNullOrEmpty(accessKey) || string.IsNullOrEmpty(secretKey))
            {
                throw new ArgumentException("SES configuration is incomplete.");
            }

            Console.WriteLine($"SES: sending email to {to}");
            Console.WriteLine($"SES Config: Region={awsRegion}, AccessKey={accessKey}");
        }
        else if (provider == "SendGrid")
        {
            var apiKey = string.Empty;

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("SendGrid API key is missing.");
            }

            Console.WriteLine($"SendGrid: sending email to {to}");
            Console.WriteLine($"SendGrid Config: APIKey={apiKey}");
        }
        else
        {
            throw new NotSupportedException($"Email provider '{provider}' is not supported.");
        }
    }
}
