using System.Diagnostics.CodeAnalysis;
using Application.Domain.Entities;
using Application.Domain.ValueObjects.Space;
using Application.Drivens.PrimaryDb.Repositories;

namespace PrimaryDbPostgreSql.Repositories;

internal record SpaceRepository : BaseRepository<Space, SpaceId>, ISpaceRepository
{
    [SetsRequiredMembers]
    public SpaceRepository(PrimaryDbPostgreSqlContext dbContext) : base(dbContext)
    {
    }
}