﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApplicationNet7.Api;
using Veracity.Services.Api;
using WebApplicationNet7.Models;

namespace WebApplicationNet7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMy _myService;
        private readonly IWtfClient _testClient;

        public HomeController(ILogger<HomeController> logger, IMy myService,IWtfClient testClient)
        {
            _logger = logger;
            _myService = myService;
            _testClient = testClient;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                var whatEver = await _testClient.GetTheThingAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            var services = await _myService.MyServices();
            return View(await _myService.Info());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
