using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WebApi.Events.Command.Account
{
    public class LogoutCommandHandler: INotificationHandler<LogoutCommand>
    {
        public async Task Handle(LogoutCommand notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.Token);
        }
    }
}