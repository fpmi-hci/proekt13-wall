using DrinkService.Interfaces;
using DrinkService.Model;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace DrinkService.Services;

public class DrinkChoiceService : IDrinkChoiceService
{
    private readonly IRepository<Drink, Guid> _drinkRepository;
    private readonly IRepository<Collection, Guid> _collectionRepository;

    public DrinkChoiceService(IRepository<Drink, Guid> repository, IRepository<Collection, Guid> collectionRepository)
    {
        _drinkRepository = repository;
        _collectionRepository = collectionRepository;
    }

    public async Task<Drink> GetRandomDrink()
    {
        var drinks = await _drinkRepository.Query();

        return GetRandomDrinkFromList(drinks);
    }

    public async Task<Drink> GetDrinkByMood(MoodFilterModel filter)
    {
        var drinks = await _drinkRepository.Query(x =>
            x.IsHot == filter.Hot && x.IsMilk == filter.Milk && x.IsStrong == filter.Strong);

        return drinks.Count > 0 ? GetRandomDrinkFromList(drinks) : await GetRandomDrink();
    }

    public async Task<Drink> GetDrinkFromCollection(Guid userId, string collectionName)
    {
        var collection = await _collectionRepository.Query(
            x => x.Name == collectionName && x.UserId == userId,
            x => x.Include(y => y.Drinks));

        if (collection.Count == 0)
        {
            throw new ArgumentException("Invalid collection name");
        }

        var drinks = collection[0].Drinks;

        return GetRandomDrinkFromList(drinks.ToList());
    }

    private static Drink GetRandomDrinkFromList(IReadOnlyList<Drink> drinks)
    {
        var num = new Random().Next(drinks.Count);

        return drinks[num];
    }
}