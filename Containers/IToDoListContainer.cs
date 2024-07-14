using ToDoListApi.Abstractions;

namespace ToDoListApi.Containers
{
    public interface IToDoListContainer
    {
        IEnumerable<ToDoList> GetAll();
        ToDoList GetByList_Id(int id);
        void Add(ToDoList list);
        void Update(ToDoList list);
        void Delete(int id);
    }
}