using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    
namespace _23haziran_web.Areas.Fatura_Paneli.Controllers
{


    [Area("Fatura_Paneli")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
