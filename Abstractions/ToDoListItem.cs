using Swashbuckle.AspNetCore.Annotations;
namespace ToDoListApi.Abstractions
{
    public class ToDoListItem
    {
        public int Id { get; set; }
        public string Description { get; set; }

    //   [SwaggerSchema(Default = false)]  
        public bool IsCompleted { get; set; } = false;
    }
}