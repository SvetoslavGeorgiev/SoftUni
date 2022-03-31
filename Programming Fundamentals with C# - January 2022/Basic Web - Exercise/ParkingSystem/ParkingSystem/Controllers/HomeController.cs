using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkingSystem.Data;


namespace ParkingSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() 
        { 
            return View(DataAccess.Cars); 
        }
    }
}
