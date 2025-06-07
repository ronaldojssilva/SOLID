// See https://aka.ms/new-console-template for more information
using EmailNotificationService.SemViolacao;

Console.WriteLine("Hello, World!");


//var smtpCreator = new SMTPEmailNotificationCreator();
//smtpCreator.SendEmail("user1@example.com", "Hello from SMTP!");

//var sesCreator = new SESEmailNotificationCreator();
//sesCreator.SendEmail("user1@example.com", "Hello from SES!");

//var sendGridCreator = new SendGridEmailNotificationCreator();
//sendGridCreator.SendEmail("user1@example.com", "Hello from SES!");

var emailNotificationService = new EmailNotificationService.SemViolacao.EmailNotificationService();
emailNotificationService.SendEmail(new SMTPEmailNotificationCreator());
emailNotificationService.SendEmail(new SESEmailNotificationCreator());
emailNotificationService.SendEmail(new SendGridEmailNotificationCreator());