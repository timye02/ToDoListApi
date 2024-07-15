using Swashbuckle.AspNetCore.Annotations;
namespace ToDoListApi.Abstractions
{
    public class ToDoListItem
    {
        public int Id { get; set; } = 0;
        public string Description { get; set; } = null;

    //   [SwaggerSchema(Default = false)]  
        public bool IsCompleted { get; set; } = false;
    }
}