using ToDoListApi.Abstractions;

namespace ToDoListApi.Containers
{
    public interface IToDoListItemContainer
    {
        // ToDoListItem SearchByItem_Id(int id);
        ToDoListItem GetByList_Item_Id(int id, int listId);
        void Add(ToDoListItem item, int listId);
        void Update(ToDoListItem item, int listId);
        void Delete(int id, int listId);
    }
}