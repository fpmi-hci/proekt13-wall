using System.Collections.ObjectModel;
using DrinkService.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace DrinkService.Services;

public class CollectionService : ICollectionService
{
    private readonly IRepository<Collection, Guid> _collectionRepository;
    private readonly IRepository<Drink, Guid> _drinkRepository;

    public CollectionService(IRepository<Collection, Guid> collectionRepository,
        IRepository<Drink, Guid> drinkRepository)
    {
        _collectionRepository = collectionRepository;
        _drinkRepository = drinkRepository;
    }

    public async Task<int> CreateCollection(Collection model) //add mapper
    {
        return await _collectionRepository.Insert(model);
    }

    public async Task<int> DeleteCollection(Guid id)
    {
        var collection = await _collectionRepository.GetById(id);

        return await _collectionRepository.Delete(collection);
    }

    public async Task<int> UpdateCollection(Collection model) //add mapper
    {
        return await _collectionRepository.Update(model);
    }

    public async Task<Collection> GetCollection(Guid id)
    {
        return await _collectionRepository.GetById(id);
    }

    public async Task<ReadOnlyCollection<Collection>> GetAll()
    {
        return await _collectionRepository.Query();
    }

    public async Task<int> AddDrinkToCollection(Guid collectionId, Guid drinkId)
    {
        var collection = await _collectionRepository.GetById(collectionId);
        var drink = await _drinkRepository.GetById(drinkId);

        var collections = drink.Collections.Append(collection);

        drink.Collections = collections;

        return drink.Collections.Count();
    }

    public async Task<int> DeleteDrinkFromCollection(Guid collectionId, Guid drinkId)
    {
        var collection = await _collectionRepository.GetById(collectionId);
        var drink = await _drinkRepository.GetById(drinkId);

        var collections = drink.Collections.Where(x => x != collection);

        drink.Collections = collections;

        return drink.Collections.Count();
    }
}