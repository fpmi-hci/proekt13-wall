using System.Collections.ObjectModel;
using DrinkService.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace DrinkService.Services;

public class DrinkService : IDrinkService
{
    private readonly IRepository<Drink, Guid> _drinkRepository;

    public DrinkService(IRepository<Drink, Guid> drinkRepository)
    {
        _drinkRepository = drinkRepository;
    }

    public async Task<int> CreateDrink(Drink model) //add mapper
    {
        return await _drinkRepository.Insert(model);
    }

    public async Task<int> DeleteDrink(Guid id)
    {
        var drink = await _drinkRepository.GetById(id);

        return await _drinkRepository.Delete(drink);
    }

    public async Task<int> UpdateDrink(Drink model) //add mapper
    {
        return await _drinkRepository.Update(model);
    }

    public async Task<Drink> GetDrink(Guid id)
    {
        return await _drinkRepository.GetById(id);
    }

    public async Task<ReadOnlyCollection<Drink>> GetAllDrinks()
    {
        return await _drinkRepository.Query();
    }
}