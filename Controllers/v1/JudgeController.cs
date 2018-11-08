using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/judge")]
    public class JudgeController : Controller
    {
        private readonly IMediator _mediator;

        public JudgeController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}