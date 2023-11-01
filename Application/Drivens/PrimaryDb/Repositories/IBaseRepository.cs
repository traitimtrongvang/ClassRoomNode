using Application.Domain.Entities;
using Application.Domain.ValueObjects.Commons;

namespace Application.Drivens.PrimaryDb.Repositories;

public interface IBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : BaseId
{
    
}