using AutoMapper;
using Lib.Database;

namespace Lib.Web;

/// <summary>
/// The AutoMapper configuration.
/// </summary>
public static class AutoMapperConfiguration
{
    /// <summary>
    /// Configures this instance.
    /// </summary>
    public static IMapper Configure()
    {
        return new MapperConfiguration(cfg =>
        {
            // cfg.CreateMap<DTO, DAO>();
        }).CreateMapper();
    }
}
