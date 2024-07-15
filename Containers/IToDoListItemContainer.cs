using ToDoListApi.Abstractions;

namespace ToDoListApi.Containers
{
    public interface IToDoListItemContainer
    {
        // ToDoListItem SearchByItem_Id(int id);
        ToDoListItem GetByList_Item_Id(int id, int listId);
        bool Add(ToDoListItem item, int listId);
        ToDoListItem Complete(int id, int listId);
        ToDoListItem Update(ToDoListItem item, int listId);
        bool Delete(int id, int listId);
    }
}