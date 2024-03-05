using AutoMapper;
using Lib.Database;

namespace Lib.Web;

/// <summary>
/// The Example controller logic.
/// </summary>
public class ExampleControllerLogic
{
    private readonly IMapper mapper;
    private readonly UnitOfWork unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExampleControllerLogic" />
    /// class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="mapper">The mapper.</param>
    public ExampleControllerLogic(IMapper mapper, UnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
}
