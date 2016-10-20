using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GZCNegotiation.Services.EtgInfoLib;

namespace GZCNegotiation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEtgInfoService etgService;
        public HomeController(IEtgInfoService etgService)
        {
            this.etgService = etgService;
        }


        public async Task<IActionResult> Index([FromQuery]string token)
        {
            var userInfo = await etgService.RegisterUserAsync(token);
            ViewData["UserName"] = userInfo.Name;
            return View();
        }

        public IActionResult About()
        {
            var userInfo = etgService.GetCurrentUser();
            ViewData["UserName"] = userInfo.Name;
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
