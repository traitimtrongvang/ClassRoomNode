using System.Diagnostics.CodeAnalysis;
using Application.Domain.Entities;
using Application.Domain.ValueObjects.Folder;
using Application.Drivens.PrimaryDb.Repositories;

namespace PrimaryDbPostgreSql.Repositories;

internal record FolderRepository : BaseRepository<Folder, FolderId>, IFolderRepository 
{
    [SetsRequiredMembers]
    public FolderRepository(PrimaryDbPostgreSqlContext dbContext) : base(dbContext)
    {
    }
}