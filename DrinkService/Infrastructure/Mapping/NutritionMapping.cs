using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.EntityMapping;
using Infrastructure.Model;

namespace Infrastructure.Mapping;

public class NutritionMapping : EntityMapping<Nutrition>
{
    public override void Configure(EntityTypeBuilder<Nutrition> builder)
    {
        builder.ToTable("Nutrition");

        builder.HasKey(x => x.Id);

        ConfigureNotNullableColumns(builder);
    }

    private static void ConfigureNotNullableColumns(EntityTypeBuilder<Nutrition> builder)
    {
        builder.Property(x => x.Calories).IsRequired();
        builder.Property(x => x.Carbohydrates).IsRequired();
        builder.Property(x => x.Fats).IsRequired();
        builder.Property(x => x.Proteins).IsRequired();
    }
}