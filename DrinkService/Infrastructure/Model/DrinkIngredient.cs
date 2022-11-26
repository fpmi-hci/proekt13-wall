using Infrastructure.Model.Base;

namespace Infrastructure.Model;

public class DrinkIngredient : EntityWithId<Guid>
{
    public Guid DrinkId { get; set; }

    public Guid IngredientId { get; set; }

    public int Amount { get; set; }

    #region NavigationProperties

    public Drink Drink { get; set; }

    public Ingredient Ingredient { get; set; }

    #endregion
}