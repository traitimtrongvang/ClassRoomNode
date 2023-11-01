using Application.Domain.ValueObjects.Commons;

namespace Application.Domain.ValueObjects.Folder;

public record FolderId(Guid Val) : BaseId(Val);