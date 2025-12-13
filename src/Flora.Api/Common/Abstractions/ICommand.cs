using MediatR;

namespace Flora.Api.Common.Abstractions
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }
}
