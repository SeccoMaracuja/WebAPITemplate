using System.Text.Json.Serialization;
using AutoMapper;
using Lamar;
using Lib.Database;
using Lib.Language;
using Lib.Mail;
using Lib.Web;
using Microsoft.EntityFrameworkCore;

namespace Web;

/// <summary>
/// The Lamar dependency injection configuration.
/// </summary>
public class LamarConfiguration
{
    /// <summary>
    /// Configure the specified registry, configuration and environment.
    /// </summary>
    /// <param name="registry">The registry.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="environment">The environment.</param>
    public static void Configure(ServiceRegistry registry, ConfigurationManager configuration, IWebHostEnvironment environment)
    {
        var connectionString = configuration.GetConnectionString("Database");

        // SMTP Mail sender configuration
        var mailSenderConfiguration = new SmtpMailSenderConfiguration();
        configuration.GetSection(nameof(SmtpMailSenderConfiguration)).Bind(mailSenderConfiguration);

        // Exception handler
        registry.AddExceptionHandler<GlobalExceptionHandler>();
        registry.AddProblemDetails();

        // Configure DatabaseContext
        registry.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        // AutoMapper
        registry.For<IMapper>().Use(AutoMapperConfiguration.Configure()).Singleton();

        // UnitOfWork
        registry.For<UnitOfWork>().Use<UnitOfWork>();

        // MailSender
        registry.For<IMailSender>().Use<SmtpMailSender>();
        registry.For<SmtpMailSenderConfiguration>().Use(mailSenderConfiguration).Singleton();

        // Resources
        registry.For<ResourcesLogic>().Use<ResourcesLogic>();

        // Controllers
        registry.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            // options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            // options.JsonSerializerOptions.WriteIndented = true;
        });

        registry.AddEndpointsApiExplorer();
        registry.AddSwaggerGen(options =>
        {
        });
    }
}
