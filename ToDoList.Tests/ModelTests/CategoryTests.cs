using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class CategoryTests : IDisposable
  {
    public void Dispose()
    {
      Category.ClearAll();
    }

    [TestMethod]
    public void CategoryConstructor_CreatesInstanceOfCategoryClass_Category()
    {
      string nameOfNewCategory = "Home Chores";
      Category anInstanceOfACategoryObject = new Category(nameOfNewCategory);
      Assert.AreEqual(typeof(Category), anInstanceOfACategoryObject.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string nameOfCategory = "Home Chores";
      Category homeChoreCategory = new Category(nameOfCategory);
      string test = homeChoreCategory.Name;
      Assert.AreEqual(nameOfCategory, test);
    }

    [TestMethod]
    public void GetId_ReturnsID_Int()
    {
      int instanceId = 1;
      Category newCategory = new Category("");
      int testID = newCategory.Id;
      Assert.AreEqual(instanceId, testID);
    }

    [TestMethod]
    public void GetAll_ReturnsAllInstancesOfCategoryObjects_List()
    {
      string nameOfCategory1 = "Home Chores";
      string nameOfCategory2 = "Work Related Tasks";
      Category firstCategory = new Category(nameOfCategory1);
      Category secondCategory = new Category(nameOfCategory2);
      // I know a list of categories would look like this:
      List<Category> allCurrentCategories = new List<Category> { firstCategory, secondCategory };
      List<Category> retrievedCategories = Category.GetAll();
      // Assert
      CollectionAssert.AreEqual(allCurrentCategories, retrievedCategories);
    }

    [TestMethod]
    public void Find_ReturnsCategoryWithSpecifiedId_Category()
    {
      string nameOfCategory1 = "Home Chores";
      string nameOfCategory2 = "Work Related Tasks";
      Category firstCategory = new Category(nameOfCategory1);
      Category secondCategory = new Category(nameOfCategory2);
      // I want to find the category object of Id 1.
      int idOfInterest = 1;
      Category foundInstance = Category.Find(idOfInterest);
      // Assert
      Assert.AreEqual(firstCategory, foundInstance);      
    }

    [TestMethod]
    public void AddItem_AddItemToCategory_ItemList()
    {
      // Make an instance of a Category
      Category nameOfCategory = new Category("Home");
      
      //Make an instance of an Item
      string newItemDescription = "dishes";
      Item instanceOfItem = new Item(newItemDescription);

      // Here's a list of items for us to compare the one made automatically.
      List<Item> listOfItems = new List<Item> {instanceOfItem};

//           let listOfItems = new List<Item> {}
      nameOfCategory.AddItem(instanceOfItem);
      List<Item> result = nameOfCategory.Items;
      CollectionAssert.AreEqual(listOfItems, result);

    }
  }
}