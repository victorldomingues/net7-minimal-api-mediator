using TodoApi.Context;
using TodoApi.Models.Commands;
using TodoApi.Models.Entities;
using TodoApi.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Handlers;

public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand, DeleteTodoResponse>
{
    private readonly ILogger<DeleteTodoHandler> _logger;
    private readonly TodoContext _context;

    public DeleteTodoHandler(ILogger<DeleteTodoHandler> logger, TodoContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<DeleteTodoResponse> Handle(DeleteTodoCommand command, CancellationToken cancellationToken)
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == command.Id);

        if (todo is null) throw new Exception($"todo {command.Id} not found");

        todo.Delete();

        _context.Todos.Entry(todo);

        var result = await _context.SaveChangesAsync();

        return new DeleteTodoResponse(
            todo.Id,
            todo.Name,
            todo.DeletedAt.GetValueOrDefault(),
            todo.Status);
    }
}
