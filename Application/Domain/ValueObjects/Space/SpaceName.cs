using Application.Domain.Exceptions;

namespace Application.Domain.ValueObjects.Space;

public record SpaceName
{
    public string Val { get; init; }

    public SpaceName(string val)
    {
        ThrowIfInvalid(val);
        Val = val;
    }

    private static void ThrowIfInvalid(string val)
    {
        if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val) || val.StartsWith(" ") || val.EndsWith(" "))
            throw new InvalidSpaceNameExc();
    }
}