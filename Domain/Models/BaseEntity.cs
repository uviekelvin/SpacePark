using MediatR;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
  public abstract class BaseEntity<T>
  {
    public string CreatedBy { get; set; }
    public DateTime? DateUpdated { get; set; }
    public string LastAction { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    int? _requestedHashCode;
    T _Id;
    public T Id
    {
      get
      {
        return _Id;
      }
      set
      {
        _Id = value;
      }
    }

    private List<INotification> _domainEvents;
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(INotification eventItem)
    {
      _domainEvents = _domainEvents ?? new List<INotification>();
      _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
      _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
      _domainEvents?.Clear();
    }

    // public bool IsTransient()
    // {
    //     return this.Id == default(T);
    // }

    // public override bool Equals(object obj)
    // {
    //     if (obj == null || !(obj is BaseEntity<T>))
    //         return false;

    //     if (Object.ReferenceEquals(this, obj))
    //         return true;

    //     if (this.GetType() != obj.GetType())
    //         return false;

    //     BaseEntity<T> item = (BaseEntity<T>)obj;

    //     if (item.IsTransient() || this.IsTransient())
    //         return false;
    //     else
    //         return item.Id == this.Id;
    // }

    // public override int GetHashCode()
    // {
    //     if (!IsTransient())
    //     {
    //         if (!_requestedHashCode.HasValue)
    //             _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

    //         return _requestedHashCode.Value;
    //     }
    //     else
    //         return base.GetHashCode();

    // }
    // public static bool operator ==(BaseEntity left, BaseEntity right)
    // {
    //     if (Object.Equals(left, null))
    //         return (Object.Equals(right, null)) ? true : false;
    //     else
    //         return left.Equals(right);
    // }

    // public static bool operator !=(BaseEntity left, BaseEntity right)
    // {
    //     return !(left == right);
    // }
  }
}