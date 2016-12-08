using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServices.DotNETCore.Web.MVC.Controllers
{
    public class CustomersController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}
