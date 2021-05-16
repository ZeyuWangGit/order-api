using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp.Order.Domain.Abstraction
{
    public abstract class Entity: IEntity
    {
        public abstract object[] GetKeys();

        public override string ToString()
        {
            return $"[Entity: {GetType().Name}] Keys = {string.Join(",", GetKeys())}";
        }

        private List<IDomainEvent> _domainEvents;

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }

    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        private int? _requestedHashCode;

        public virtual TKey Id { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] { Id };
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity<TKey>))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            Entity<TKey> item = (Entity<TKey>)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }

            return base.GetHashCode();
        }
        public bool IsTransient()
        {
            return EqualityComparer<TKey>.Default.Equals(Id, default);
        }
        public override string ToString()
        {
            return $"[Entity: {GetType().Name}] Id = {Id}";
        }

        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            return left?.Equals(right) ?? Equals(right, null);
        }

        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {
            return !(left == right);
        }
    }
}
