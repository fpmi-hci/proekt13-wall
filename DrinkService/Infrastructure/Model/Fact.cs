using Infrastructure.Model.Base;

namespace Infrastructure.Model;

public class Fact : EntityWithId<Guid>
{
    public string Description { get; set; }
    
    public Guid DrinkId { get; set; }
    
    #region NavigationProperties
    
    public Drink Drink { get; set; }
    
    #endregion
}