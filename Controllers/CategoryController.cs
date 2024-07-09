using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BulkyBooks.Models;
using BulkyBooks.Data;

namespace BulkyBooks.Controllers;

public class CategoryController(MyDbContext context) : Controller
{
    private readonly MyDbContext _context = context;
    public IActionResult Index()
    {
        IEnumerable<Catagory> CatagoryList = _context.Categories;

        return View(CatagoryList);
    }
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
