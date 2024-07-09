using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BulkyBooks.Models;
using BulkyBooks.Data;
using Microsoft.EntityFrameworkCore;

namespace BulkyBooks.Controllers;

public class CategoryController(MyDbContext context) : Controller
{
    private readonly MyDbContext _context = context;
    public IActionResult Index()
    {
        // var conn = _context.Database.GetConnectionString();
        var CatagoryList = _context.Categories.ToList();

        return View(CatagoryList);
    }
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
