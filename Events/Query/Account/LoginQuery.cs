using MediatR;
using WebApi.Events.Command.Account;

namespace WebApi.Events.Query.Account
{
    public class LoginQuery: IRequest<LoginRequest>
    {
        public string Login { set; get; }
        public string Password { set; get; }
    }
}