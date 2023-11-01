using Application.Drivens.PrimaryDb.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Drivens.PrimaryDb;

public abstract class PrimaryDbContext : DbContext
{
    public abstract ISpaceRepository SpaceRepo { get; init; }
    public abstract IFolderRepository FolderRepo { get; init; }

    protected PrimaryDbContext()
    {
    }

    protected PrimaryDbContext(DbContextOptions options) : base(options)
    {
    }
}