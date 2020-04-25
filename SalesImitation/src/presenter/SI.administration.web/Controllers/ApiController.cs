using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SI.Administration.Web.ActionFilters;

namespace SI.Administration.Web.Controllers {

    [ApiController]
    [Route ("api/[controller]")]
     [ServiceFilter(typeof(ErrorHandlerFilter))]
    public abstract class ApiController : ControllerBase {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator> ());
    }
}