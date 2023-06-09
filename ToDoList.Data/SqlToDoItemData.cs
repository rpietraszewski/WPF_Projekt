﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Logic;
using ToDoListLogic;

namespace ToDoList.Data
{
    public class SqlToDoItemData : IToDoItemData
    {
        private readonly ToDoListDbContext db;

        public SqlToDoItemData(ToDoListDbContext db)
        {
            this.db = db;
        }

        public void Add(ToDoItem newItem)
        {
            db.ToDoItems.Add(newItem);
            db.SaveChanges();
        }

        public int GetCountOfItems(bool state = false)
        {
            var query = (from i in db.ToDoItems
                        where i.IsCompleted == state
                        select i)
                        .Count();

            return query;
        }

        public IEnumerable<ToDoItem> GetItemsByNameAndCategory(string name = null, string category = null)
        {
            var query = from i in db.ToDoItems
                        where (string.IsNullOrEmpty(name) || i.ItemName.Contains(name)) &&
                            (string.IsNullOrEmpty(category) || i.Category.Contains(category))
                        orderby i.DueDate.HasValue descending,  // Display items with DueDate first
                                i.DueDate                       // Display items with DueDate == null after
                        select i;

            return query;
        }

        public IEnumerable<ToDoItem> GetItemsByNameAndState(string name = null, bool state = false)
        {
            var query = from i in db.ToDoItems
                        where (string.IsNullOrEmpty(name) || i.ItemName.Contains(name)) &&
                        i.IsCompleted == state
                        orderby i.DueDate.HasValue descending,  // Display items with DueDate first
                                i.DueDate                       // Display items with DueDate == null after
                        select i;

            return query;
        }

        public void Update(ToDoItem updatedItem)
        {
            var result = db.ToDoItems.SingleOrDefault(i => i.Id == updatedItem.Id);
            
            if (result != null)
            {
                if (result != null)
                {
                    result.ItemName = updatedItem.ItemName;
                    result.DueDate = updatedItem.DueDate;
                    result.Priority = updatedItem.Priority;
                    result.IsCompleted = updatedItem.IsCompleted;
                    result.Category = updatedItem.Category;
                }
            }

            db.SaveChanges();
        }
    }
}
