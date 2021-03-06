using Microsoft.AspNetCore.Mvc;

namespace dotnet6_webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if (ListWeatherForecast == null || !ListWeatherForecast.Any()){
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    //[Route("Get/weatherforecast")]
    //[Route("Get/weatherforecast2")]
    //[Route("[action]")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogDebug("API return weatherforest list"); //should be print in console. it's very important to check what is happening, especially in cloud 
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast){
        ListWeatherForecast.Add(weatherForecast);
        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index){
        ListWeatherForecast.RemoveAt(index);
        return Ok();
    }
}
