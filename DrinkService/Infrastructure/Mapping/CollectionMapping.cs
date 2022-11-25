using Infrastructure.EntityMapping;
using Infrastructure.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

public class CollectionMapping : EntityMapping<Collection>
{
    public override void Configure(EntityTypeBuilder<Collection> builder)
    {
        builder.ToTable("Collection");

        builder.HasKey(x => x.Id);

        ConfigureNotNullableColumns(builder);
        ConfigureUniqueKeys(builder);
        ConfigureForeignKeys(builder);
        ConfigureDefaultValues(builder);
    }

    private static void ConfigureDefaultValues(EntityTypeBuilder<Collection> builder)
    {
        builder.Property(x => x.UserId).HasDefaultValue(null);
    }

    private static void ConfigureNotNullableColumns(EntityTypeBuilder<Collection> builder)
    {
        builder.Property(x => x.Name).IsRequired();
    }

    private static void ConfigureUniqueKeys(EntityTypeBuilder<Collection> builder)
    {
        builder.HasIndex(x => new {x.Name, x.UserId}).IsUnique();
    } 
    
    private static void ConfigureForeignKeys(EntityTypeBuilder<Collection> builder)
    {
        builder.HasMany(x => x.Drinks).WithMany(x => x.Collections);
    }
}