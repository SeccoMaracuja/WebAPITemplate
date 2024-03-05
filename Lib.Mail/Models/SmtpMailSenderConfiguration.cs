namespace Lib.Mail;

/// <summary>
/// The SMTP mail sender configuration.
/// </summary>
public class SmtpMailSenderConfiguration
{
    /// <summary>
    /// Gets or sets the SMTP from.
    /// </summary>
    /// <value>The SMTP from.</value>
    public string SmtpFrom { get; set; } = default!;

    /// <summary>
    /// Gets or sets the SMTP host.
    /// </summary>
    /// <value>The SMTP host.</value>
    public string SmtpHost { get; set; } = default!;

    /// <summary>
    /// Gets or sets the SMTP password.
    /// </summary>
    /// <value>The SMTP password.</value>
    public string SmtpPassword { get; set; } = default!;

    /// <summary>
    /// Gets or sets the SMTP port.
    /// </summary>
    /// <value>The SMTP port.</value>
    public int SmtpPort { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [SMTP TLS].
    /// </summary>
    /// <value><c>true</c> if [SMTP TLS]; otherwise, <c>false</c>.</value>
    public bool SmtpTls { get; set; }

    /// <summary>
    /// Gets or sets the SMTP username.
    /// </summary>
    /// <value>The SMTP username.</value>
    public string SmtpUsername { get; set; } = default!;
}
