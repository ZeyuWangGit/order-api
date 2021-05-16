namespace Exp.Order.Domain.Abstraction
{
    public interface IEntity
    {
        object[] GetKeys();
    }

    public interface IEntity<out TKey> : IEntity
    {
        TKey Id { get; }
    }
}
