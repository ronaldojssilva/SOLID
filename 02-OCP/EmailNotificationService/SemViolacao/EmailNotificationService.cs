namespace EmailNotificationService.SemViolacao;

class EmailNotificationService
{
    public void SendEmail(EmailNotificationCreator provider)
    {
        provider.SendEmail("user@example.com", "Hello from Email Notification Service!");
    }
}

interface IEMailnotification
{
    void Send(string to, string message);
}

class SMTPEmailNotification : IEMailnotification  
{
    private readonly string smtpServer;
    private readonly string userName;
    private readonly string password;

    public SMTPEmailNotification(
        string smtpServer,
        string userName,
        string password)
    {
        this.smtpServer = smtpServer;
        this.userName = userName;
        this.password = password;
    }

    public void Send(string to, string message)
    {
        Console.WriteLine($"SMTP: Sending email to {to}");
        Console.WriteLine($"SMTP Config: Server={smtpServer}, User={userName}");
    }
}

class sESEmailNotification : IEMailnotification
{
    private readonly string awsRegion;
    private readonly string awsAccessKey;
    private readonly string awsSecretKey;

    public sESEmailNotification(
        string awsRegion,
        string awsAccessKey,
        string awsSecretKey)
    {
        this.awsRegion = awsRegion;
        this.awsAccessKey = awsAccessKey;
        this.awsSecretKey = awsSecretKey;
    }

    public void Send(string to, string message)
    {
        Console.WriteLine($"SES: Sending email to {to}");
        Console.WriteLine($"SES Config: Region={awsRegion}, AccessKey={awsAccessKey}");
    }
}

class SendGridEmailNotification : IEMailnotification
{
    private readonly string apiKey;
    public SendGridEmailNotification(string apiKey)
    {
        this.apiKey = apiKey;
    }
    public void Send(string to, string message)
    {
        Console.WriteLine($"SendGrid: Sending email to {to}");
        Console.WriteLine($"SendGrid Config: APIKey={apiKey}");
    }
}

abstract class EmailNotificationCreator
{
    abstract public IEMailnotification CreateEmailNotification();

    public void SendEmail(string to, string message)
    {
        var emailNotification = CreateEmailNotification();
        emailNotification.Send(to, message);
    }
}

class SMTPEmailNotificationCreator : EmailNotificationCreator
{
    public override IEMailnotification CreateEmailNotification()
    {
        string smtpServer = "smtpServer";
        string userName = "userName";
        string password = "password";

        if (string.IsNullOrEmpty(smtpServer) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("SMTP configuration is incomplete.");
        }

        return new SMTPEmailNotification(smtpServer, userName, password);
    }
}

class SESEmailNotificationCreator : EmailNotificationCreator
{
    public override IEMailnotification CreateEmailNotification()
    {
        string awsRegion = "awsRegion";
        string awsAccessKey = "awsAccessKey";
        string awsSecretKey = "awsSecretKey";

        if (string.IsNullOrEmpty(awsRegion) || string.IsNullOrEmpty(awsAccessKey) || string.IsNullOrEmpty(awsSecretKey))
        {
            throw new ArgumentException("SES configuration is incomplete.");
        }
        return new sESEmailNotification(awsRegion, awsAccessKey, awsSecretKey);
    }
}

class SendGridEmailNotificationCreator : EmailNotificationCreator
{
    public override IEMailnotification CreateEmailNotification()
    {
        string apiKey = string.Empty; // Assume this is set from configuration or environment variable
        if (string.IsNullOrEmpty(apiKey))
        {
            throw new ArgumentException("SendGrid API key is not set.");
        }

        return new SendGridEmailNotification(apiKey);
    }
}