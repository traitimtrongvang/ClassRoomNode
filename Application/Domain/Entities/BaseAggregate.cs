using Application.Domain.ValueObjects.Commons;

namespace Application.Domain.Entities;

public abstract class BaseAggregate<TId> : BaseEntity<TId> 
    where TId : BaseId
{
    
}