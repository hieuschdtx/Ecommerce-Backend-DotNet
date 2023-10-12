using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace shopecommerce.API.Controllers
{
    [Route("api/product-price")]
    [ApiController]
    public class ProductPriceController : BaseController
    {
        public ProductPriceController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }
    }
}
