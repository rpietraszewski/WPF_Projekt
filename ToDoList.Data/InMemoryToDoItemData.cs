using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ToDoListLogic;
using System.Threading.Tasks;
using ToDoList.Logic;

namespace ToDoList.Data
{
    public class InMemoryToDoItemData : IToDoItemData
    {
        List<ToDoItem> toDoItems;

        public InMemoryToDoItemData()
        {
            toDoItems = new List<ToDoItem>()
            {
                new ToDoItem
                {
                    Id = 1,
                    ItemName = "Test 1",
                    DueDate = null,
                    Priority = Priority.Medium,
                    Category = Category.Job,
                    IsCompleted = false,
                },
                new ToDoItem
                {
                    Id = 2,
                    ItemName = "Test 2",
                    DueDate = null,
                    Priority = Priority.Low,
                    Category = Category.Health,
                    IsCompleted = false,
                },
                new ToDoItem
                {
                    Id = 3,
                    ItemName = "Test 3",
                    DueDate = DateTime.Now,
                    Priority = Priority.High,
                    Category = Category.School,
                    IsCompleted = false,
                },
            };
        }

        public void Add(ToDoItem newItem)
        {
            toDoItems.Add(newItem);
            newItem.Id = toDoItems.Max(i => i.Id) + 1;
        }

        public int GetCountOfItems(bool state = false)
        {
            return (from i in toDoItems 
                    where i.IsCompleted == state
                    select i)
                    .Count();
        }

        public IEnumerable<ToDoItem> GetItemsByNameAndCategory(string name = null, string category = null)
        {
            var query = from i in toDoItems
                        where (string.IsNullOrEmpty(name) || i.ItemName.Contains(name)) &&
                            (string.IsNullOrEmpty(category) || i.Category.Contains(category))
                        orderby i.ItemName
                        select i;
            return query;
        }

        public IEnumerable<ToDoItem> GetItemsByNameAndState(string name = null, bool state = false)
        {
            var query = from i in toDoItems
                        where (string.IsNullOrEmpty(name) || i.ItemName.Contains(name)) &&
                        i.IsCompleted == state
                        orderby i.ItemName
                        select i;
            return query;
        }

        public void Update(ToDoItem updatedItem)
        {
            var item = toDoItems.SingleOrDefault(i => i.Id == updatedItem.Id);
            
            if(item != null)
            {
                item.ItemName = updatedItem.ItemName;
                item.DueDate = updatedItem.DueDate;
                item.Priority = updatedItem.Priority;
                item.IsCompleted = updatedItem.IsCompleted;
                item.Category = updatedItem.Category;
            }
        }
    }
}
