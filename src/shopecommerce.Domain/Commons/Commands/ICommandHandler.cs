using MediatR;

namespace shopecommerce.Domain.Commons.Commands
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TReponse> : IRequestHandler<TCommand, TReponse> where TCommand : ICommand<TReponse>
    {
    }
}
