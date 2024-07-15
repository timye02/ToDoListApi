using ToDoListApi.Abstractions;

namespace ToDoListApi.Containers
{
    public class MemToDoList : IToDoListContainer
    {
        private readonly List<ToDoList> _toDoLists = new List<ToDoList>();

        // Returns all to-do lists in the repository
        public IEnumerable<ToDoList> GetAll() => _toDoLists;

        //Returns the to-do list with the specified id, or null if no such to-do list exists.
        public ToDoList GetByList_Id(int id)
        {
            var toDoList = _toDoLists.Find(l => l.Id == id);
            return toDoList;
        }

        public void Add(ToDoList list)
        {
            list.Id = _toDoLists.Count;
            _toDoLists.Add(list);
        }

        public void Update(ToDoList list)
        {
            var existingList = GetByList_Id(list.Id);
            if (existingList != null)
            {
                existingList.Title = list.Title;
                existingList.Items = list.Items;
            }
        }

        public void Delete(int id)
        {
            var list = GetByList_Id(id);
            if (list != null)
            {
                _toDoLists.Remove(list);
            }
        }
    }
}