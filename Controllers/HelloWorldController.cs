using Microsoft.AspNetCore.Mvc;

namespace dotnet6_webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;
    HomeworksContext dbcontext;

    public HelloWorldController(IHelloWorldService helloWorld, HomeworksContext db)
    {
        helloWorldService = helloWorld;
        dbcontext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDataBase()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}