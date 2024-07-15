using ToDoListApi.Abstractions;

namespace ToDoListApi.Containers
{
    public class MemToDoListItem : IToDoListItemContainer
    {
        private readonly IToDoListContainer _toDoListContainer;

        public MemToDoListItem(IToDoListContainer toDoListContainer)
        {
            _toDoListContainer = toDoListContainer;
        }

        // // Returns the 
        // public ToDoListItem SearchByItem_Id(int id)
        // {
        //     foreach (var list in _toDoListContainer.GetAll())
        //     {
        //         var item = list.Items.FirstOrDefault(i => i.Id == id);
        //         if (item != null) return item;
        //     }
        //     return null;
        // }

        // Returns the item object at id and listId
        public ToDoListItem GetByList_Item_Id(int id, int listId)
        {
            var list = _toDoListContainer.GetByList_Id(listId);
            var item = list?.Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                return item;
            }
            return null;
        }

        public void Add(ToDoListItem item, int listId)
        {
            var list = _toDoListContainer.GetByList_Id(listId);
            if (list != null)
            {
                // see if item count works and see if u want it to rank then by priority
                item.Id = list.Items.Count;
                list.Items.Add(item);
            }
        }

        public void Update(ToDoListItem item, int listId)
        {
            var existingItem = GetByList_Item_Id(item.Id, listId);
            if (existingItem != null)
            {
                existingItem.Description = item.Description;
                existingItem.IsCompleted = item.IsCompleted;
            }
        }

        public void Delete(int id, int listId)
        {
            var list = _toDoListContainer.GetByList_Id(listId);
            var item = list?.Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                list.Items.Remove(item);
            }
        }
    }
}