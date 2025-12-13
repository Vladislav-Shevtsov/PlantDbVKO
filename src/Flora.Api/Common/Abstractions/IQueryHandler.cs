using MediatR;

namespace Flora.Api.Common.Abstractions
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}
