using AutoMapper;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using System.Net;

namespace shopecommerce.Application.Commands.OrderCommand.UpdateOrder
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand, BaseResponseDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public async Task<BaseResponseDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.id.ToString());
            if(order is null)
            {
                return new BaseResponseDto(false, "Không tồn tại đơn hàng", (int)HttpStatusCode.BadRequest);
            }

            var orderDetails = await _orderDetailRepository.GetAllOrderDetailByOrderId(request.id.ToString());
            if(orderDetails is null)
            {
                return new BaseResponseDto(false, "Không tồn tại các chi tiết của đơn hàng này", (int)HttpStatusCode.BadRequest);
            }

            if(order.status != 2)
            {
                foreach(var od in orderDetails)
                {
                    var product = await _productRepository.GetByIdAsync(od.product_id);
                    if(product is null)
                    {
                        return new BaseResponseDto(false, "Sản phẩm đặt đã không còn trong cửa hàng", (int)HttpStatusCode.BadRequest);
                    }
                    product.SetStock(od.quantity);
                    product.UpdateModifiedTime();

                    await _productRepository.UpdateAsync(product);
                    await _productRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
                }
            }

            var orderMapping = _mapper.Map(request, order);
            await _orderRepository.UpdateAsync(orderMapping);
            await _orderRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Cập nhật thành công", (int)HttpStatusCode.OK);
        }
    }
}
