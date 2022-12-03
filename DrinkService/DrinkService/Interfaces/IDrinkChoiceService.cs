using DrinkService.Model;
using Infrastructure.Model;

namespace DrinkService.Interfaces;

public interface IDrinkChoiceService
{
    public Task<Drink> GetRandomDrink();

    public Task<Drink> GetDrinkFromCollection(Guid userId, string collectionName);

    public Task<Drink> GetDrinkByMood(MoodFilterModel filter);
}