using System.Net;
using System.Net.Mail;

namespace Lib.Mail;

/// <summary>
/// SmtpMailSender.
/// </summary>
public class SmtpMailSender : IMailSender
{
    private readonly SmtpMailSenderConfiguration confguration;

    /// <summary>
    /// Initializes a new instance of the <see cref="SmtpMailSender" /> class.
    /// </summary>
    /// <param name="confguration">The confguration.</param>
    public SmtpMailSender(SmtpMailSenderConfiguration confguration)
    {
        this.confguration = confguration;
    }

    /// <summary>
    /// Sends the mail asynchronous.
    /// </summary>
    /// <param name="to">To.</param>
    /// <param name="subject">The subject.</param>
    /// <param name="body">The body.</param>
    public async Task SendMailAsync(string to, string subject, string body)
    {
        using var client = new SmtpClient(confguration.SmtpHost, confguration.SmtpPort)
        {
            EnableSsl = confguration.SmtpTls,
            Credentials = new NetworkCredential(confguration.SmtpUsername, confguration.SmtpPassword),
            Timeout = 20000, // 20s
        };

        using var message = new MailMessage(confguration.SmtpFrom, to, subject, body);
        message.IsBodyHtml = true;

        try
        {
            await client.SendMailAsync(message);
        }
        catch (Exception e)
        {
            throw new Exception("Email konnte nicht gesendet werden", e);
        }
    }
}
