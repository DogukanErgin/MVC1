using _23haziran_web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _23haziran_web.ViewCompenents
{
    public class FooterViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var liste = new List<Product> { 
            new Product {ProductName="klavye",Id=5,Quantity=7},
            new Product {ProductName="mouse",Id=6,Quantity=4},
            new Product {ProductName="monitör",Id=3,Quantity=11}
            
            };
            ViewBag.veri = liste;
            return View();

        }
    }
}
