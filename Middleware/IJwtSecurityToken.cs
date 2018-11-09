using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Middleware
{
    public interface IJwtSecurityToken
    {
        Task<string> Generate(int userId, int[] roleIds);
    }
}
