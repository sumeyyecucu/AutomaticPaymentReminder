
using AutomaticPaymentReminder.Application.Interfaces.IServices;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;


namespace AutomaticPaymentReminder.Infrastructure.Services;

public class EmailService : IEmailService
{

    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendReminderAsync(string toEmail, string subscriptionProvider, DateTime paymentDate)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Ödeme Hatırlatıcı", _config["Mail:From"]));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = "Ödeme Hatırlatması";
        message.Body = new TextPart("plain")
        {
            Text =
                $"{subscriptionProvider} tarafından sağlanan aboneliğinizin son ödemesinin {paymentDate:dd/MM/yyyy} tarihine kadar yapılması gerekmektir."
        };

        using var client = new SmtpClient();
        await client.ConnectAsync(_config["Mail:Host"], int.Parse(_config["Mail:Port"]), SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_config["Mail:Username"], _config["Mail:Password"]);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}