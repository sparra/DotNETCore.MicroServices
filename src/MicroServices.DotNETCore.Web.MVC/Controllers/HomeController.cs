using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using MicroServices.DotNETCore.Domain.CORE.Models;
using Microsoft.AspNetCore.Hosting;

namespace MicroServices.DotNETCore.Web.MVC.Controllers
{    
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment env;
        public HomeController(IHostingEnvironment env)
        {
            this.env = env;
        }        
        public IActionResult Index()
        {           
            List<DockerCommand> model = null;
            var client = new HttpClient();
            var apiuri = env.IsDevelopment() ? "http://localhost:9000/api/values" : "http://apiservice:9000/api/values";   
            var task = client.GetAsync(apiuri).ContinueWith((t) =>
            {
                var response = t.Result;
                var readtask = response.Content.ReadAsAsync<List<DockerCommand>>();
                readtask.Wait();
                model = readtask.Result;
            });
            task.Wait();
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
