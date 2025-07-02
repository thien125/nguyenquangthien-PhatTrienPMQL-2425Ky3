using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class HeThongPhanPhoiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    [HttpPost]
    public IActionResult Index(HeThongPhanPhoi ht)
    {
        string strOutput = "Xin chào " + ht.MaHTPP + " - " + ht.TenHTPP;
        ViewBag.infoHTPP = strOutput;
        return View();
    }
    }
}