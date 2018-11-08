using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entities;
using WebApi.Events.Command.Account;
using WebApi.Helpers;
using WebApi.Repository;

namespace WebApi.Events.Query.Account
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginRequest>
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(AppSettings appSettings, IUserRepository userRepository)
        {
            _appSettings = appSettings;
            _userRepository = userRepository;
        }

        public async Task<LoginRequest> Handle(LoginQuery query, CancellationToken cancellationToken)
        {                  
            User user =  _userRepository.GetAll().FirstOrDefault(x => x.Username == query.Login && x.Password == query.Password);
            if (user == null)
                return null;

            LoginRequest result = new LoginRequest {FirstName = user.FirstName, LastName = user.LastName};

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.SessionTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);  
            result.Token = tokenHandler.WriteToken(token);
            
            return result;
        }
    }
}