using MediatR;

namespace shopecommerce.Domain.Commons.Commands
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
        Guid id { get; }
    }
    public interface ICommand : IRequest
    {
        Guid id { get; }
    }
}
