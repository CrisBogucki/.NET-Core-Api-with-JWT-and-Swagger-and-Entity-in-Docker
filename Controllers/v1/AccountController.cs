using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Entities;
using WebApi.Events.Command.Account;
using WebApi.Events.Query.Account;
using WebApi.Helpers;

namespace WebApi.Controllers
{   
    [Authorize]
    [ApiController]
    [Route("api/v1/account")]
    public partial class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User userParam)
        {
            var user = await _mediator.Send(new LoginQuery() { Login = userParam.Username, Password = userParam.Password });
                
            if (user == null)
                return BadRequest(new {message = "Username or password is incorrect"});

            return Ok(user);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var token = await HttpTools.GetTokenRequest(HttpContext);
            await _mediator.Publish(new LogoutCommand(){ Token = token });
            
            return Ok();
        }
    }
}