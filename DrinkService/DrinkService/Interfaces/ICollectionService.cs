using System.Collections.ObjectModel;
using Infrastructure.Model;

namespace DrinkService.Interfaces;

public interface ICollectionService
{
    Task<int> CreateCollection(Collection model);

    Task<int> DeleteCollection(Guid id);

    Task<int> UpdateCollection(Collection model);

    Task<Collection> GetCollection(Guid id);

    Task<ReadOnlyCollection<Collection>> GetAll();

    Task<int> AddDrinkToCollection(Guid collectionId, Guid drinkId);

    Task<int> DeleteDrinkFromCollection(Guid collectionId, Guid drinkId);
}