using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BulkyBooks.Models;
using BulkyBooks.Data;

namespace BulkyBooks.Controllers;

public class CategoryController(MyDbContext context) : Controller
{
    private readonly MyDbContext _context = context;

    public IActionResult IndexCategory()
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
        // removing enpty spaces from edn of data
        newCategory.Name = newCategory.Name.Trim();

        if (newCategory.Name == newCategory.DisplayOrder.ToString())
        {
            ModelState.Clear();
            ModelState.AddModelError("CustomeError", "The display Order can not be same as Category Name.");
            TempData["Message"] = "Category creation failed!";
            TempData["Class"] = "alert-danger";
            return View("CreateCategory");
        }
        else
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
    }

    //GET
    public IActionResult EditCategory(int Id)
    {
        var targerCategory = _context.Categories.Find(Id);
        return View(targerCategory);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditCategory(Catagory newCategory)
    {
        // removing enpty spaces from edn of data
        newCategory.Name = newCategory.Name.Trim();

        if (newCategory.Name == newCategory.DisplayOrder.ToString())
        {
            ModelState.Clear();
            ModelState.AddModelError("CustomeError", "The display Order can not be same as Category Name.");
            TempData["Message"] = "Edit failed!";
            TempData["Class"] = "alert-danger";
            return View("CreateCategory");
        }
        else
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(newCategory);
                _context.SaveChanges();
                TempData["Message"] = "Changed saved successfully!";
                TempData["Class"] = "alert-success";
                return RedirectToAction("CreateCategory");//  to go to some ither page of some other controller you have tp pass a second peremeter controlelName in this function
            }
            TempData["Message"] = "Update failed!\nChanger not saved!";
            TempData["Class"] = "alert-danger";
            return View("CreateCategory");
        }
    }

    public IActionResult DeleteCategory(int id)
    {
        var targetCategory = _context.Categories.Find(id);
        return View(targetCategory);
    }

    [HttpPost, ActionName("DeleteCategory")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteCategoryPost(int id)
    {
        var targetCategory = _context.Categories.Find(id);
        if (targetCategory == null)
        {
            TempData["Message"] = $"Category with ID {id} Not Found.";
            TempData["Class"] = "alert-danger";
        }
        else
        {
            _context.Categories.Remove(targetCategory);
            _context.SaveChanges();
            TempData["Message"] = $"Category with ID {id} successfully deleted.";
            TempData["Class"] = "alert-success";
        }
        return RedirectToAction("IndexCategory");
    }
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

