using MediatR;

namespace shopecommerce.Domain.Commons.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
