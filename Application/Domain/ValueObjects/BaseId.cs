using System.Diagnostics.CodeAnalysis;

namespace Application.Domain.ValueObjects;

public abstract record BaseId
{
    public Guid Val { get; init; }

    [SetsRequiredMembers]
    protected BaseId(Guid val)
    {
        Val = val;
    }

    protected BaseId()
    {
        Val = Guid.NewGuid();
    }
}