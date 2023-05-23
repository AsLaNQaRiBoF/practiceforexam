using Microsoft.AspNetCore.Mvc;

namespace isdeLANN.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
