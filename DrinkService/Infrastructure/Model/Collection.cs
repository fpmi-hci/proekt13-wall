using Infrastructure.Model.Base;

namespace Infrastructure.Model;

public class Collection: EntityWithId<Guid>
{
    public string Name { get; set; }
    
    public Guid? UserId { get; set; }
    
    #region NavigationProperties

    public IEnumerable<Drink> Drinks { get; set; }

    #endregion
}