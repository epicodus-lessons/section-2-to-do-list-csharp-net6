using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class CategoryTests
  {
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
  }
}