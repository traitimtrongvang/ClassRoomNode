using Application.Domain.ValueObjects;

namespace Application.Domain.Entities;

public abstract class BaseEntity<TId> where TId : BaseId, new()
{
    public TId Id { get; init; } = new();

    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = default;
}