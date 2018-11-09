using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApi.Middleware;
using WebApi.Repository;

namespace WebApi.Events.Query.Account
{
    public class LoginQueryHandler : INotification, IRequestHandler<LoginQuery, LoginRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtSecurityToken _jwtSecurityToken;

        public LoginQueryHandler(IUserRepository userRepository, IJwtSecurityToken jwtSecurityToken)
        {
            _userRepository = userRepository;
            _jwtSecurityToken = jwtSecurityToken;
        }

        public async Task<LoginRequest> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(x => x.Username == query.Login && x.Password == query.Password);
            if (user == null)
                return null;

            var result = new LoginRequest()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = await _jwtSecurityToken.Generate(user.Id, new []{0})
            };
            return result;
        }
    }
}