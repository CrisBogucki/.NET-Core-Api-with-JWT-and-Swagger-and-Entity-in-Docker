using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;

namespace WebApi.Repository
{
    
    public class UserRepository: IUserRepository
    {
        private readonly List<User> _users = new List<User>
        { 
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" } 
        };
        
        public IEnumerable<User> GetAll()
        {
            return _users.Select(x => { x.Password = null; return x; });
        }
    }
}