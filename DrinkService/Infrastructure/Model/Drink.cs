using Infrastructure.Model.Base;

namespace Infrastructure.Model;

public class Drink : EntityWithId<Guid>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Receipt { get; set; }

    public int Strength { get; set; }

    public bool IsStrong { get; set; }

    public bool IsMilk { get; set; }

    public bool IsHot { get; set; }

    public Guid NutritionId { get; set; }

    #region NavigationProperties

    public Nutrition Nutrition { get; set; }

    public IEnumerable<Fact> Facts { get; set; }

    public IEnumerable<Collection> Collections { get; set; }

    #endregion
}