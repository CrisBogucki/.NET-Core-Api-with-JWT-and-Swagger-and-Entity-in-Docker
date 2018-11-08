using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}