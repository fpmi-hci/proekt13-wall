using Infrastructure.Model.Base;

namespace Infrastructure.Model;

public class Ingredient : EntityWithId<Guid>
{
    public string Name { get; set; }
}