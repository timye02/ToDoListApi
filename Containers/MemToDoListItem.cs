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

        // Returns the item object at id and listId
        public ToDoListItem GetByList_Item_Id(int id, int listId)
        {
            var list = _toDoListContainer.GetByList_Id(listId);
            ToDoListItem item = null;

            if (list != null && list.Items != null)
            {
                item = list.Items.FirstOrDefault(i => i.Id == id);
            }

            return item;
        }

        public bool Add(ToDoListItem item, int listId)
        {
            var list = _toDoListContainer.GetByList_Id(listId);
            if (list != null)
            {
                // see if item count works and see if u want it to rank then by priority
                item.Id = list.Items.Count;
                list.Items.Add(item);
                return true;
            }
            return false;
        }

        public ToDoListItem Complete(int id, int listId)
        {
            var existingItem = GetByList_Item_Id(id, listId);
            if (existingItem != null)
            {
                existingItem.IsCompleted = true;
                return existingItem;
            }
            return null;

        }
        public ToDoListItem Update(ToDoListItem item, int listId)
        {
            var existingItem = GetByList_Item_Id(item.Id, listId);
            if (existingItem != null)
            {
                existingItem.Description = item.Description;
                existingItem.IsCompleted = item.IsCompleted;
                return existingItem;
            }
            return null;
        }

        public bool Delete(int id, int listId)
        {
            var list = _toDoListContainer.GetByList_Id(listId);
            ToDoListItem item = null;

            if (list != null && list.Items != null)
            {
                item = list.Items.FirstOrDefault(i => i.Id == id);
                if (item != null){
                    list.Items.Remove(item);
                    return true; // removed successfully 
                }
            }
            return false;
        }
    }
}