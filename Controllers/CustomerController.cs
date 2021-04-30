using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EventApplicationCore.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /<controller>/ Userinformation
        public IActionResult Dashboard()
        {
            return View();
        }        
    }
}
