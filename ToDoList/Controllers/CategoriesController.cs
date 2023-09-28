using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allExistingCategoryInstances = Category.GetAll();
      return View(allExistingCategoryInstances);
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/categories")]
    public ActionResult Create(string userEnteredCategoryName)
    {
      Category makeANewOne = new Category(userEnteredCategoryName);
      return RedirectToAction("Index");
    }

    // [HttpGet("/categories/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Category searchAndFound = Category.Find(id);
    //   return View(searchAndFound);
    // }
  }
}