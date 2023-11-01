namespace Application.Drivings.Models.Requests;

public interface ICommandRequest<TBody> where TBody : notnull
{
    public TBody Body { get; init; }
}