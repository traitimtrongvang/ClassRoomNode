using Application.Drivings.Models.Requests;
using MediatR;

namespace Application.Drivings.Pipelines;

public record CommandValidationPipeline<TReq, TBody, TRes> : IPipelineBehavior<TReq, TRes> 
    where TReq : IBaseRequest, ICommandRequest<TBody>
    where TBody : notnull
{
    public Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken stopToken)
    {
        // TODO
        return next();
    }
}