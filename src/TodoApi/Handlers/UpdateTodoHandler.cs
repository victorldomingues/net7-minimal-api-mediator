using TodoApi.Context;
using TodoApi.Models.Commands;
using TodoApi.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Handlers;

public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, UpdateTodoResponse>
{
    private readonly ILogger<UpdateTodoHandler> _logger;
    private readonly TodoContext _context;

    public UpdateTodoHandler(ILogger<UpdateTodoHandler> logger, TodoContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<UpdateTodoResponse> Handle(UpdateTodoCommand command, CancellationToken cancellationToken)
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == command.Id);

        if (todo is null) throw new Exception($"todo {command.Id} not found");

        todo.Update(command.Name);

        _context.Todos.Entry(todo);

        var result = await _context.SaveChangesAsync();

        return new UpdateTodoResponse(
            todo.Id,
            todo.Name,
            todo.UpdatedAt.GetValueOrDefault(),
            todo.Status);
    }
}
