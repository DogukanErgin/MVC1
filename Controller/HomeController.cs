using _23haziran_web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace _23haziran_web.Controllers
{
    public class HomeController : Controller 
    {
        public IActionResult Index()  
        {
            return View();
        }
          }
       
    }

