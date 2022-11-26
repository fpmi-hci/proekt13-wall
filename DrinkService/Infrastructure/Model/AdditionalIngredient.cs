using Infrastructure.Model.Base;

namespace Infrastructure.Model;

public class AdditionalIngredient : EntityWithId<Guid>
{
    public string Name { get; set; }
}