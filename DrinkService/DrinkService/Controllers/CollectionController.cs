using DrinkService.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;

namespace DrinkService.Controllers;

[ApiController]
[Route("collections/")]
public class CollectionController : ControllerBase
{
    private readonly ICollectionService _collectionService;

    public CollectionController(ICollectionService service)
    {
        _collectionService = service;
    }


    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Collection>> GetCollection(Guid id)
    {
        return Ok(await _collectionService.GetCollection(id));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteCollection(Guid id)
    {
        return Ok(await _collectionService.DeleteCollection(id));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCollection(Collection collection)
    {
        return Ok(await _collectionService.UpdateCollection(collection));
    }

    [HttpPost]
    public async Task<ActionResult> CreateCollection(Collection collection)
    {
        return Ok(await _collectionService.CreateCollection(collection));
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _collectionService.GetAll());
    }

    [HttpPut("add/{collectionId:guid}/{drinkId:guid}")]
    public async Task<ActionResult> AddDrinkToCollection(Guid collectionId, Guid drinkId)
    {
        return Ok(await _collectionService.AddDrinkToCollection(collectionId, drinkId));
    }

    [HttpPut("remove/{collectionId:guid}/{drinkId:guid}")]
    public async Task<ActionResult> RemoveDrinkFromCollection(Guid collectionId, Guid drinkId)
    {
        return Ok(await _collectionService.DeleteDrinkFromCollection(collectionId, drinkId));
    }
}