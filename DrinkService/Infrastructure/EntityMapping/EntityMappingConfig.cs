using Microsoft.EntityFrameworkCore;

using Infrastructure.Mapping;

namespace Infrastructure.EntityMapping;

public static class EntityMappingConfig
{
    public static void RegisterMappings(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null)
        {
            throw new ArgumentNullException(nameof(modelBuilder));
        }

        RegisterDrinkMapping(modelBuilder);
        RegisterIngredientMapping(modelBuilder);
        RegisterCollectionMapping(modelBuilder);
        RegisterAdditionalIngredientMapping(modelBuilder);
    }

    private static void RegisterAdditionalIngredientMapping(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AdditionalIngredientMapping());
    }

    private static void RegisterCollectionMapping(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CollectionMapping());
    }

    private static void RegisterIngredientMapping(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new IngredientMapping());
    }

    private static void RegisterDrinkMapping(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DrinkMapping());
        modelBuilder.ApplyConfiguration(new DrinkIngredientMapping());
        modelBuilder.ApplyConfiguration(new FactMapping());
        modelBuilder.ApplyConfiguration(new NutritionMapping());
    }
}