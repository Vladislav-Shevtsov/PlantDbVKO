using MediatR;

namespace Flora.Api.Common.Abstractions
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
