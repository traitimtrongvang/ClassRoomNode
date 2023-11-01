using Application.Domain.Exceptions;

namespace Application.Domain.ValueObjects.Commons;

public record UserId
{
    public string Val { get; init; }

    public UserId(string val)
    {
        ThrowIfInvalid(val);
        Val = val;
    }

    private void ThrowIfInvalid(string val)
    {
        if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val))
            throw new InvalidUserIdExc();    
    }
}