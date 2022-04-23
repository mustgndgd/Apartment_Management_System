using Microsoft.AspNetCore.Mvc;

namespace Apartment.App.Web.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
