using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BulkyBooks.Models;

namespace BulkyBooks.Controllers;

public class LandingPageController() : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
