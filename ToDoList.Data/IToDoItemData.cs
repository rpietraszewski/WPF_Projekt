using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoListLogic;

namespace ToDoList.Data
{
    public interface IToDoItemData
    {
        IEnumerable<ToDoItem> GetItemsByNameAndState(string name = null, bool state = false);
        IEnumerable<ToDoItem> GetItemsByNameAndCategory(string name = null, string category = null);
        void Add(ToDoItem newItem);
        void Update(ToDoItem updatedItem);
        int GetCountOfItems(bool state = false);
    }
}
