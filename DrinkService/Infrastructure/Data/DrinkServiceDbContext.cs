using Infrastructure.EntityMapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public sealed class DrinkServiceDbContext : DbContext
{
    public DrinkServiceDbContext(DbContextOptions options) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        EntityMappingConfig.RegisterMappings(modelBuilder);
    }

    private IEnumerable<object> GetChangedEntities()
    {
        ChangeTracker.DetectChanges();

        return ChangeTracker.Entries()
            .Where(x =>
                x.State is EntityState.Modified or EntityState.Added)
            .Select(x => x.Entity);
    }
}