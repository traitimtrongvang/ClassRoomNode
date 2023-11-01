using Application.Domain.Entities;
using Application.Domain.ValueObjects.Folder;

namespace Application.Drivens.PrimaryDb.Repositories;

public interface IFolderRepository : IBaseRepository<Folder, FolderId>
{
    
}