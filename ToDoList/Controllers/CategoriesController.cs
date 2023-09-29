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

    // dynamic link with changing id
    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id)
    {
      // // Use a Dictionary to connect the instance of Category with its list of item objects.
      // // Dictionary of searchAndFound.Name connected with Item.
      Dictionary<string, object> model = new Dictionary<string, object>();
      // Use the id given, and search for the instance of the category object.
      Category searchAndFound = Category.Find(id);
      List<Item> categoryItems = searchAndFound.Items;
      model.Add("category", searchAndFound);
      model.Add("items", categoryItems);
      return View(model);
    }

    // This one creates new Items within a given Category, not new Categories:

    [HttpPost("/categories/{categoryId}/items")]
    public ActionResult Create(int categoryId, string itemDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.Find(categoryId);
      Item newItem = new Item(itemDescription);
      foundCategory.AddItem(newItem);
      List<Item> categoryItems = foundCategory.Items;
      model.Add("items", categoryItems);
      model.Add("category", foundCategory);
      return View("Show", model);
    }
  }
}


      // Category searchAndFound = Category.Find(id);
      // return View(searchAndFound);      

// // searchAndFound looks like this:
// // - Family Tasks
// //   - Name
// //   - Id = 3
// //   - To Do Items
// //   --- Groceries
// //   --- Walk the dog
// //   --- Take out the trash

// // categoryItems looks like this:
// //   - To Do Items
// //   --- Groceries
// //   --- Walk the dog
// //   --- Take out the trash


// // This got sent from CategoriesControllers via "/categories/{id}" to Show.cshtml.
// dictionaryProvided {
//   {"category", searchAndFound},
//   {"items", categoryItems}
// }
// // It gets accessed by doing @Model

// // Example of how to use a key "C" to access a value "cat".
// myDictionary["C"] = "cat";

// // Statement found in Show.cshtml
// @Model["items"]
// // Equivalent statement if calling dictionary key "items" directly.
// dictionaryProvided["items"]
// // Result would be categoryItems.
// // searchAndFound.Items
// // In our example, @Model["items"] gives us this:
// //   --- Dishes
// //   --- Walk the dog
// //   --- Take out the trash

// @Model["category"].Name // is equal to "Family Tasks"
// @Model["category"].Id // is equal to 3


// @foreach (Item item in @Model["items"])
// @item.Id
// @item.Description
// // @Model["items"] gives us this:
// //   --- Dishes (has an Id)(has a Description)
// //   --- Walk the dog (has an Id)(has a Description)
// //   --- Take out the trash (has an Id)(has a Description)

