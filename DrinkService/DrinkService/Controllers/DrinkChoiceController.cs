using Microsoft.AspNetCore.Mvc;

namespace DrinkService.Controllers;

[ApiController]
public class DrinkChoiceController: ControllerBase
{
    public DrinkChoiceController()
    {
        
    }

    [HttpGet("getString")]
    public ActionResult<string> GetString(int number)
    {
        return Ok($"string {number}");
    }
}