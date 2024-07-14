using ToDoListApi.Abstractions;

namespace ToDoListApi.Containers
{
    public class MemToDoList : IToDoListContainer
    {
        private readonly List<ToDoList> _toDoLists = new List<ToDoList>();

        public IEnumerable<ToDoList> GetAll() => _toDoLists;

        public ToDoList GetByList_Id(int id) => _toDoLists.FirstOrDefault(l => l.Id == id);

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
                existingList.Name = list.Name;
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