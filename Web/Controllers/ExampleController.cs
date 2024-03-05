using Lib.Web;
using Microsoft.AspNetCore.Mvc;

namespace Web;

/// <summary>
/// The ExampleController.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ExampleController
{
    private readonly ExampleControllerLogic controllerLogic;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExampleController"/> class.
    /// </summary>
    /// <param name="controllerLogic">The OpeningHourControllerLogic.</param>
    public ExampleController(ExampleControllerLogic controllerLogic)
    {
        this.controllerLogic = controllerLogic;
    }
}
