using Application.Domain.ValueObjects.Commons;
using Application.Domain.ValueObjects.Space;

namespace Application.Domain.Entities;

public class Space : BaseAggregate<SpaceId>
{
    public required SpaceName Name { get; set; }
    
    public required SpaceType Type { get; init; }
    
    #region Relationships

    public required UserId OwnerUserId { get; init; }

    #endregion

    #region Navigations

    public List<Folder>? FolderList { get; init; }

    #endregion
}