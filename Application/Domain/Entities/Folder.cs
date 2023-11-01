using Application.Domain.ValueObjects.Folder;
using Application.Domain.ValueObjects.Space;

namespace Application.Domain.Entities;

public class Folder : BaseAggregate<FolderId>
{
    public required FolderName Name { get; set; }

    #region Relationships

    public required SpaceId? SpaceId { get; set; }

    public required FolderId? RootFolderId { get; set; }

    #endregion

    #region Navigations
    
    public Space? Space { get; set; }

    public Folder? RootFolder { get; set; }

    public List<Folder>? SubFolderList { get; init; }

    #endregion
}