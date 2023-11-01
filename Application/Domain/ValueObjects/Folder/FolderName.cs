using Application.Domain.Exceptions;

namespace Application.Domain.ValueObjects.Folder;

public record FolderName
{
    public string Val { get; init; }

    public FolderName(string val)
    {
        ThrowIfInvalid(val);
        Val = val;
    }

    private static void ThrowIfInvalid(string val)
    {
        if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val) || val.StartsWith(" ") || val.EndsWith(" "))
            throw new InvalidFolderNameExc();
    }
}