using MediatR;

namespace WebApi.Events.Command.Account
{
    public class LogoutCommand: INotification
    {
        public string Token { get; set; }
    }
}