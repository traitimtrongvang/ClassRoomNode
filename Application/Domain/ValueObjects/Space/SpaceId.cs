using Application.Domain.ValueObjects.Commons;

namespace Application.Domain.ValueObjects.Space;

public record SpaceId(Guid Val) : BaseId(Val);