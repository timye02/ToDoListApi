namespace ToDoListApi.Abstractions
{   
    public class ToDoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ToDoListItem> Items { get; set; } = new List<ToDoListItem>();
    }
}
