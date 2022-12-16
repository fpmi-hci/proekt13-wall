using System.Collections.ObjectModel;
using Infrastructure.Model;

namespace DrinkService.Interfaces;

public interface IDrinkService
{
    Task<int> CreateDrink(Drink model);

    Task<int> DeleteDrink(Guid id);

    Task<int> UpdateDrink(Drink model);

    Task<Drink> GetDrink(Guid id);

    Task<ReadOnlyCollection<Drink>> GetAllDrinks();
}