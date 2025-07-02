using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class DaiLyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    [HttpPost]
    public IActionResult Index(DaiLy dl)
    {
        string strOutput = "Xin chào " + dl.MaDaiLy + " - " + dl.TenDaiLy + " - " + dl.DiaChi + " - " + dl.NguoiDaiDien + " - " + dl.DienThoai;
        ViewBag.infoDaiLy = strOutput;
        return View();
    }
    }
}