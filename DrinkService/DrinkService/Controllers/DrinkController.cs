using DrinkService.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;

namespace DrinkService.Controllers;

[ApiController]
[Route("drinks/")]
public class DrinkController : ControllerBase
{
    private readonly IDrinkService _drinkService;

    public DrinkController(IDrinkService service)
    {
        _drinkService = service;
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Drink> GetDrink(Guid id)
    {
        return Ok(_drinkService.GetDrink(id));
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteDrink(Guid id)
    {
        return Ok(_drinkService.DeleteDrink(id));
    }

    [HttpPut]
    public ActionResult UpdateDrink(Drink drink)
    {
        return Ok(_drinkService.UpdateDrink(drink));
    }

    [HttpPost]
    public ActionResult CreateDrink(Drink drink)
    {
        return Ok(_drinkService.CreateDrink(drink));
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        return Ok(_drinkService.GetAllDrinks());
    }
}