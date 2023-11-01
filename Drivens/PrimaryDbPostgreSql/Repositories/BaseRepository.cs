using System.Diagnostics.CodeAnalysis;
using Application.Domain.Entities;
using Application.Domain.ValueObjects.Commons;
using Application.Drivens.PrimaryDb.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PrimaryDbPostgreSql.Repositories;

internal abstract record BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : BaseId
{
    public required DbSet<TEntity> DbSet { get; init; }

    public required PrimaryDbPostgreSqlContext DbContext { get; init; }

    [SetsRequiredMembers]
    protected BaseRepository(PrimaryDbPostgreSqlContext dbContext)
    {
        DbContext = dbContext;
        DbSet = DbContext.Set<TEntity>();
    }
}