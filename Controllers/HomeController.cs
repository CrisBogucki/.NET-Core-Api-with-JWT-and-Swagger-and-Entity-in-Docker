using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using WebApi.Models.Home;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger/");
        }
        
        public async Task<IActionResult> Info()
        {
            var model = new InfoModel();
            var authenticateInfo = await HttpContext.Authentication.GetAuthenticateInfoAsync("Bearer");
            foreach (KeyValuePair<string, string> item in authenticateInfo.Properties.Items)
            {
                    model.keys.Add(item);
            }

            return View(model);
        }
        
        
    }
}