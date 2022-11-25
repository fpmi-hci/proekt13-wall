using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using Infrastructure.EntityMapping;

using Infrastructure.Model;

namespace Infrastructure.Mapping;

public class FactMapping: EntityMapping<Fact>
{
    public override void Configure(EntityTypeBuilder<Fact> builder)
    {
        builder.ToTable("Fact");

        builder.HasKey(x => x.Id);

        ConfigureNotNullableColumns(builder);
        ConfigureForeignKeys(builder);
    }

    private static void ConfigureForeignKeys(EntityTypeBuilder<Fact> builder)
    {
        builder.HasOne(x => x.Drink).WithMany(x => x.Facts).HasForeignKey(x => x.DrinkId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private static void ConfigureNotNullableColumns(EntityTypeBuilder<Fact> builder)
    {
        builder.Property(x => x.DrinkId).IsRequired();
        builder.Property(x => x.Description).IsRequired();
    }
}