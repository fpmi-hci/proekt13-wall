namespace DrinkService.Model;

public class DrinkPostModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Receipt { get; set; }

    public int Strength { get; set; }

    public bool IsStrong { get; set; }

    public bool IsMilk { get; set; }

    public bool IsHot { get; set; }

    public NutritionPostModel Nutrition { get; set; }

    public List<string> Facts { get; set; }
}