using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace shopecommerce.API.Controllers
{
    public class PromotionController : BaseController
    {
        public PromotionController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

    }
}
