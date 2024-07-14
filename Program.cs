using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoListApi.Containers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add Singletons/Depedencies to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IToDoListContainer, MemToDoList>();
builder.Services.AddSingleton<IToDoListItemContainer, MemToDoListItem>();

/*

// Add services to the container (for future memory repurposes)
builder.Services.AddControllers();
builder.Services.AddScoped<IToDoListContainer, MemToDoList>();
builder.Services.AddScoped<IToDoListItemContainer, MemToDoListItem>();

*/


// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoList API", Version = "v1" });
    c.EnableAnnotations();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoList API v1"));
}
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

