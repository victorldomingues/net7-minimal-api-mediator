using TodoApi.Behaviors;
using TodoApi.Context;
using TodoApi.Extensions;
using TodoApi.Models.Commands;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoContext>(options =>
    options.UseInMemoryDatabase(databaseName: "TodosDb"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly)
       .AddOpenBehavior(typeof(LoggingRequestBehavior<,>));
});


var app = builder.Build();

app.MapGet("/todos", (TodoContext context) => context.Todos);
app.MapGet("/todos/{id}", (Guid id, TodoContext context)
    => context.Todos.FirstOrDefaultAsync(x => x.Id == id));

app.MapPost<CreateTodoCommand>("/todos");
app.MapPut<UpdateTodoCommand>("/todos/{id}");
app.MapDelete<DeleteTodoCommand>("/todos/{id}");
app.MapPost<CompleteTodoCommand>("/todos/{id}/complete");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.Run();