using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CnBateBlogWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using CnBateBlogWeb.Common;

namespace CnBateBlogWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _env = env;
            _logger = logger;
        }

        public IActionResult Index()
        {
            #region 开发/生产环境
            var environmentStr = string.Empty;
            if (_env.IsDevelopment())
            {
                environmentStr += "开发环境";
            }
            else if (_env.IsProduction())
            {
                environmentStr += "生产环境";
            }
            else
            {
                environmentStr += "未知环境";
            } 
            #endregion

            ViewBag.Environment = $"当前系统处于:{environmentStr}";
            ViewBag.SqlServerConnection = $"{Appsettings.app("SqlServer", "SqlServerConnection")}";

            ViewBag.Location = Environment.GetEnvironmentVariable("Location");

            return View();
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
