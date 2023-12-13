using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using shopecommerce.Domain.Commons;
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
        private readonly ISendMailRepository _sendMailRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateOrderCommandHandler(IOrderRepository oderRepository, IUserRepository userRepository,
            IProductRepository productRepository, IMapper mapper, IOrderDetailRepository orderDetailRepository, ISendMailRepository sendMailRepository, IWebHostEnvironment webHostEnvironment)
        {
            _oderRepository = oderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _orderDetailRepository = orderDetailRepository;
            _sendMailRepository = sendMailRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<BaseResponseDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var contentProduct = "";
            var styleTd1 = "scope=\"col\" style=\"color:#636363;border:1px solid #e5e5e5;vertical-align:middle;padding:12px;text-align:left;width:auto\"";
            var styleTd2 = "scope=\"col\" style=\"color:#636363;border:1px solid #e5e5e5;vertical-align:middle;padding:12px;text-align:center;width:auto\"";
            var styleTd3 = "scope=\"col\" style=\"color:#636363;border:1px solid #e5e5e5;vertical-align:middle;padding:12px;text-align:right;width:auto\"";

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
            order.SetCodeOrder();
            order.SetIsVAT(order.bill_invoice);

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

            if(order.status == 2)
            {
                foreach(var cart in request.carts)
                {
                    var product = await _productRepository.GetByIdAsync(cart.product_id);
                    if(!(product.stock <= 0))
                    {
                        product.SetStock(cart.quantity);
                        product.UpdateModifiedTime();

                        await _productRepository.UpdateAsync(product);
                        await _productRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
                    }
                }
            }

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
                var data = await _orderDetailRepository.AddAsync(orderDetail);
                await _orderDetailRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

                if(data is not null)
                {
                    var product = await _productRepository.GetByIdAsync(cart.product_id);
                    contentProduct += "<tr>";
                    contentProduct += $"<td {styleTd1}>" + product.name + "</td>";
                    contentProduct += $"<td {styleTd2}>" + cart.quantity + "</td>";
                    contentProduct += $"<td {styleTd3}>" + FormatNumber.fNumber(cart.total_amount, 0) + "&nbsp;<span>₫</span>" + "</td>";
                    contentProduct += "</tr>";
                }
            }

            string templatesPath = Path.Combine(_webHostEnvironment.WebRootPath, "templates");
            string filePath = Path.Combine(templatesPath, "EmailOrder.html");
            if(File.Exists(filePath))
            {
                var contentCustomer = File.ReadAllText(filePath);
                var transportFee = order.is_vat ? 0 : 30000;

                contentCustomer = contentCustomer.Replace("{{code}}", order.code);
                contentCustomer = contentCustomer.Replace("{{productOrder}}", contentProduct);
                contentCustomer = contentCustomer.Replace("{{createdAt}}", order.created_at.ToString("dd/MM/yyyy HH:mm tt"));
                contentCustomer = contentCustomer.Replace("{{customerName}}", order.customer_name);
                contentCustomer = contentCustomer.Replace("{{customerPhone}}", order.customer_phone);
                contentCustomer = contentCustomer.Replace("{{customerEmail}}", order.customer_email);
                contentCustomer = contentCustomer.Replace("{{customerAddress}}", order.customer_address);
                contentCustomer = contentCustomer.Replace("{{billInvoice}}", FormatNumber.fNumber(order.bill_invoice, 0));
                contentCustomer = contentCustomer.Replace("{{transportFee}}", FormatNumber.fNumber(transportFee, 0));
                contentCustomer = contentCustomer.Replace("{{totalAmount}}", FormatNumber.fNumber(transportFee + order.bill_invoice, 0));

                var isSuccess = await _sendMailRepository.SendEmailAsync(order.customer_email, "Cửa hàng MeatDeli - Đơn hàng #" + order.code, contentCustomer);

                if(!isSuccess)
                {
                    return new BaseResponseDto(false, "Có lỗi xảy ra trong quá trình tạo đơn hàng", (int)HttpStatusCode.BadRequest);
                }
            }
            return new BaseResponseDto(true, "Tạo đơn hàng thành công", (int)HttpStatusCode.Created);
        }
    }
}
