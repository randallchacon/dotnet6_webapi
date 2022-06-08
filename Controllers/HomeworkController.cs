using dotnet6_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet6_webapi;

[Route("api/[controller]")]
public class HomeworkController : ControllerBase
{
    IHomeworksService homeworksService;

    public HomeworkController(IHomeworksService service)
    {
        homeworksService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {        
        return Ok(homeworksService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Homework homework)
    {
        homeworksService.Save(homework);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Homework homework)
    {
        homeworksService.Update(id, homework);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        homeworksService.Delete(id);
        return Ok();
    }
}