using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstASPNETCORE.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult List()
        {
            ViewData["Name"] = "Светослав Георгиев";
            return View();
        }
    }
}
