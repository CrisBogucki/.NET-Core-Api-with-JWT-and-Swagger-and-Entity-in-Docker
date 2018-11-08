using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Home;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger/");
        }
        
        public IActionResult Info()
        {

            return View(new InfoModel());
        }
        
        
    }
}