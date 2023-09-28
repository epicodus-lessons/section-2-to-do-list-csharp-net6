using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    // Field for the entire Category class.
    private static List<Category> _instances = new List<Category> { };

    // Fields for instances of Category class.
    public string Name { get; set; }
    public int Id { get; }
    public List<Item> Items { get; set; }
  
    // Constructor
    public Category(string nameOfCategory)
    {
      Name = nameOfCategory;
      _instances.Add(this);
      Id = _instances.Count;
      // Holds a list of items
      Items = new List<Item> { };
    }
  }
}





// List of Categories
// - Home Tasks
//   - Name
//   - Id
//   - To Do Items
//   --- Groceries
//   --- Walk the dog
//   --- Take out the trash

// - Work Related Tasks
//   - Name
//   - Id
//   - To Do Items
//   --- Groceries
//   --- Walk the dog
//   --- Take out the trash

// - Family Tasks
//   - Name
//   - Id
//   - To Do Items
//   --- Groceries
//   --- Walk the dog
//   --- Take out the trash