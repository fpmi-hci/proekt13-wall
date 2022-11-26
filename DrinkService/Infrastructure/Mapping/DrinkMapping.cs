using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.EntityMapping;
using Infrastructure.Model;

namespace Infrastructure.Mapping;

public class DrinkMapping : EntityMapping<Drink>
{
    public override void Configure(EntityTypeBuilder<Drink> builder)
    {
        builder.ToTable("Drink");

        builder.HasKey(x => x.Id);

        ConfigureNotNullableColumns(builder);
        ConfigureUniqueKeys(builder);
        ConfigureForeignKeys(builder);
    }

    private static void ConfigureNotNullableColumns(EntityTypeBuilder<Drink> builder)
    {
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Receipt).IsRequired();
        builder.Property(x => x.Strength).IsRequired();
        builder.Property(x => x.NutritionId).IsRequired();
    }

    private static void ConfigureUniqueKeys(EntityTypeBuilder<Drink> builder)
    {
        builder.HasIndex(x => x.Name).IsUnique();
    }

    private static void ConfigureForeignKeys(EntityTypeBuilder<Drink> builder)
    {
        builder.HasOne(x => x.Nutrition).WithOne();
        builder.HasMany(x => x.Facts).WithOne(x => x.Drink).HasForeignKey(x => x.DrinkId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(x => x.Collections).WithMany(x => x.Drinks);
    }
}