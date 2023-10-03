using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace shopecommerce.API.Controllers
{
    public class ColorController : BaseController
    {
        public ColorController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }
    }
}
