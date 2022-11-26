using Infrastructure.Model.Base;

namespace Infrastructure.Model;

public class Nutrition : EntityWithId<Guid>
{
    public int Carbohydrates { get; set; }

    public int Fats { get; set; }

    public int Proteins { get; set; }

    public int Calories { get; set; }
}