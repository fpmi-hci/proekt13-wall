using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.EntityMapping;
using Infrastructure.Model;

namespace Infrastructure.Mapping;

public class AdditionalIngredientMapping : EntityMapping<AdditionalIngredient>
{
    public override void Configure(EntityTypeBuilder<AdditionalIngredient> builder)
    {
        builder.ToTable("AdditionalIngredient");

        builder.HasKey(x => x.Id);

        ConfigureNotNullableColumns(builder);
        ConfigureUniqueKeys(builder);
    }

    private static void ConfigureNotNullableColumns(EntityTypeBuilder<AdditionalIngredient> builder)
    {
        builder.Property(x => x.Name).IsRequired();
    }

    private static void ConfigureUniqueKeys(EntityTypeBuilder<AdditionalIngredient> builder)
    {
        builder.HasIndex(x => x.Name).IsUnique();
    }
}