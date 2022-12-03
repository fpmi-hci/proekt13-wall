using DrinkService.Interfaces;
using DrinkService.Model;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;

namespace DrinkService.Controllers;

[ApiController]
public class DrinkChoiceController : ControllerBase
{
    private readonly IDrinkChoiceService _choiceService;

    public DrinkChoiceController(IDrinkChoiceService service)
    {
        _choiceService = service;
    }

    [HttpGet("random")]
    public ActionResult<Drink> Random()
    {
        return Ok(_choiceService.GetRandomDrink());
    }

    [HttpGet("fromCollection")]
    public ActionResult<Drink> FromCollection(Guid userId, string collectionName)
    {
        return Ok(_choiceService.GetDrinkFromCollection(userId, collectionName));
    }

    [HttpGet("byMood")]
    public ActionResult<Drink> ByMood([FromQuery] MoodFilterModel filter)
    {
        return Ok(_choiceService.GetDrinkByMood(filter));
    }
}