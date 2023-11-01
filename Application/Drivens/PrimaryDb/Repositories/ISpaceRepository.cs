using Application.Domain.Entities;
using Application.Domain.ValueObjects.Space;

namespace Application.Drivens.PrimaryDb.Repositories;

public interface ISpaceRepository : IBaseRepository<Space, SpaceId>
{
    
}