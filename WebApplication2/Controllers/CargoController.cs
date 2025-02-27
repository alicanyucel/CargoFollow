using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class CargoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
