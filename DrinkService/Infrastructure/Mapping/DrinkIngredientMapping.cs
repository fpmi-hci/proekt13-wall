using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.EntityMapping;
using Infrastructure.Model;

namespace Infrastructure.Mapping;

public class DrinkIngredientMapping : EntityMapping<DrinkIngredient>
{
    public override void Configure(EntityTypeBuilder<DrinkIngredient> builder)
    {
        builder.ToTable("DrinkIngredient");

        builder.HasKey(x => x.Id);

        ConfigureNotNullableColumns(builder);
        ConfigureUniqueKeys(builder);
        ConfigureForeignKeys(builder);
    }

    private static void ConfigureNotNullableColumns(EntityTypeBuilder<DrinkIngredient> builder)
    {
        builder.Property(x => x.Amount).IsRequired();
        builder.Property(x => x.DrinkId).IsRequired();
        builder.Property(x => x.IngredientId).IsRequired();
    }

    private static void ConfigureUniqueKeys(EntityTypeBuilder<DrinkIngredient> builder)
    {
        builder.HasIndex(x => new { x.DrinkId, x.IngredientId }).IsUnique();
    }

    private static void ConfigureForeignKeys(EntityTypeBuilder<DrinkIngredient> builder)
    {
        builder.HasOne(x => x.Drink).WithMany().OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Ingredient).WithMany().OnDelete(DeleteBehavior.Cascade);
    }
}