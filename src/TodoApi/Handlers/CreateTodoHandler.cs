using TodoApi.Context;
using TodoApi.Models.Commands;
using TodoApi.Models.Entities;
using TodoApi.Models.Responses;
using MediatR;

namespace TodoApi.Handlers;

public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, CreateTodoResponse>
{
    private readonly ILogger<CreateTodoHandler> _logger;
    private readonly TodoContext _context;

    public CreateTodoHandler(ILogger<CreateTodoHandler> logger, TodoContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<CreateTodoResponse> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Todo(request.Name);

        _context.Todos.Add(todo);

        var result = await _context.SaveChangesAsync();

        return new CreateTodoResponse(todo.Id, todo.Name, todo.CreatedAt, todo.Status);
    }
}
