using AutoMapper;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.OrderCommand.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, BaseResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _oderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository oderRepository, IUserRepository userRepository,
            IProductRepository productRepository, IMapper mapper, IOrderDetailRepository orderDetailRepository)
        {
            _oderRepository = oderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<BaseResponseDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            foreach(var cart in request.carts)
            {
                if(await _productRepository.GetByIdAsync(cart.product_id) is null)
                {
                    return new BaseResponseDto(false, ProductMessages.product_id_not_existed, (int)HttpStatusCode.BadRequest);
                }
            }

            var order = _mapper.Map<Orders>(request);
            order.SetCreatedTime();
            order.SetDateTimeWithoutTimeZone(request.delivery_date);

            if(!string.IsNullOrEmpty(request.userId))
            {
                var user = await _userRepository.GetByIdAsync(request.userId);
                if(user is null)
                {
                    return new BaseResponseDto(false, UserMessages.user_id_is_not_existed, (int)HttpStatusCode.BadRequest);
                }
            }
            order.setUserId(request.userId);

            await _oderRepository.AddAsync(order);
            await _oderRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            foreach(var cart in request.carts)
            {
                var orderDetail = new OrderDetails
                {
                    id = Guid.NewGuid().ToString(),
                    order_id = order.id,
                    product_id = cart.product_id,
                    quantity = cart.quantity,
                    total_amount = cart.total_amount,
                };
                await _orderDetailRepository.AddAsync(orderDetail);
                await _orderDetailRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
            }
            return new BaseResponseDto(true, "Tạo đơn hàng thành công", (int)HttpStatusCode.Created);
        }
    }
}
