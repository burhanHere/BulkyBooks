using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BulkyBooks.Models;
using BulkyBooks.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyBooks.Controllers;

public class CategoryController(MyDbContext context) : Controller
{
    private readonly MyDbContext _context = context;

    public IActionResult Index()
    {
        // var conn = _context.Database.GetConnectionString();
        IEnumerable<Catagory> CatagoryList = _context.Categories.ToList();
        return View(CatagoryList.Reverse());
    }
    //GET
    public IActionResult CreateCategory()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]//this is added to prevent corss site request forgery genrates a kwy in the form the at post request validstes the kay
    public IActionResult CreateCategory(Catagory newCategory)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            TempData["Message"] = "Category created successfully!";
            TempData["Class"] = "alert-success";
            return RedirectToAction("CreateCategory");//  to go to some ither page of some other controller you have tp pass a second peremeter controlelName in this function
        }
        TempData["Message"] = "Category creation failed!";
        TempData["Class"] = "alert-danger";
        return View("CreateCategory");
    }


    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
