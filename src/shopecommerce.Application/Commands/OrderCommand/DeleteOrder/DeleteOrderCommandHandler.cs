using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using System.Net;

namespace shopecommerce.Application.Commands.OrderCommand.DeleteOrder
{
    public class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand, BaseResponseDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<BaseResponseDto> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.id.ToString());
            if(order is null)
            {
                return new BaseResponseDto(false, "Không tồn tại đơn hàng", (int)HttpStatusCode.BadRequest);
            }

            await _orderDetailRepository.DeleteManyOrderDetailByOrderId(request.id.ToString());
            await _orderDetailRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            await _orderRepository.DeleteAsync(order);
            await _orderRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Xóa đơn hàng thành công", (int)HttpStatusCode.OK);
        }
    }
}
