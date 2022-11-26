namespace Infrastructure.Model.Base;

public class EntityWithId<T> : IEntity<T>
{
    public T Id { get; set; }
}

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}