using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace WebApi.Helpers
{
    public static class HttpTools
    {
        public static async Task<string> GetTokenRequest(HttpContext httpContext)
        {
            return await httpContext.GetTokenAsync("access_token");
        }
    }
}