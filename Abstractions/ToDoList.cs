namespace ToDoListApi.Abstractions
{   
    public class ToDoList
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = null;
        public List<ToDoListItem> Items { get; set; } = new List<ToDoListItem>();
        
    }
}
