namespace ToDoListApi.Abstractions
{
    public class ToDoListItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}