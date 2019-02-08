namespace Portfolio.Domain
{
    public interface IEntity
    {
    }

    public interface IEntity<out TKey> : IEntity
    {
        TKey Id { get; }
    }
}
