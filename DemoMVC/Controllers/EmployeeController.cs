using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    [HttpPost]
    public IActionResult Index(Employee ep)
    {
        string strOutput = "Xin chào " + ep.EmployeeId + " - " + ep.PersonId + " - " + ep.FullName + " - "+ ep.Address + " - " + ep.Age;
        ViewBag.infoEmployee = strOutput;
        return View();
    }
    }
}