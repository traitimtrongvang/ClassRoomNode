using System.Diagnostics.CodeAnalysis;
using Application.Domain.Entities;
using Application.Drivens.PrimaryDb;
using Application.Drivens.PrimaryDb.Repositories;
using Microsoft.EntityFrameworkCore;
using PrimaryDbPostgreSql.EntityConfigurations;
using PrimaryDbPostgreSql.Repositories;

namespace PrimaryDbPostgreSql;

internal sealed class PrimaryDbPostgreSqlContext : PrimaryDbContext
{
    #region Repositories

    public override required ISpaceRepository SpaceRepo { get; init; }
    
    public override required IFolderRepository FolderRepo { get; init; }

    #endregion

    #region DbSets

    public required DbSet<Space> Spaces { get; init; } = null!;

    public required DbSet<Folder> Folders { get; init; } = null!;

    #endregion
    
    [SetsRequiredMembers]
    public PrimaryDbPostgreSqlContext(DbContextOptions options) : base(options)
    {
        SpaceRepo = new SpaceRepository(this);
        FolderRepo = new FolderRepository(this);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityConfiguration<,>).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}