namespace Lib.Mail;

/// <summary>
/// The IMailSender interface.
/// </summary>
public interface IMailSender
{
    /// <summary>
    /// Sends the mail asynchronous.
    /// </summary>
    /// <param name="to">To.</param>
    /// <param name="subject">The subject.</param>
    /// <param name="body">The body.</param>
    Task SendMailAsync(string to, string subject, string body);
}
