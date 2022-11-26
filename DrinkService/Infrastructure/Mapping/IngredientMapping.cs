using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using Infrastructure.EntityMapping;
using Infrastructure.Model;

namespace Infrastructure.Mapping;

public class IngredientMapping : EntityMapping<Ingredient>
{
    public override void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable("Ingredient");

        builder.HasKey(x => x.Id);

        ConfigureNotNullableColumns(builder);
    }

    private static void ConfigureNotNullableColumns(EntityTypeBuilder<Ingredient> builder)
    {
        builder.Property(x => x.Name).IsRequired();
    }
}