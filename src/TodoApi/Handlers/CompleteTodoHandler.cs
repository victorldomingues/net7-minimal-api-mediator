using TodoApi.Context;
using TodoApi.Models.Commands;
using TodoApi.Models.Entities;
using TodoApi.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Handlers;

public class CompleteTodoHandler : IRequestHandler<CompleteTodoCommand, CompleteTodoResponse>
{
    private readonly ILogger<CompleteTodoCommand> _logger;
    private readonly TodoContext _context;

    public CompleteTodoHandler(ILogger<CompleteTodoCommand> logger, TodoContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<CompleteTodoResponse> Handle(CompleteTodoCommand command, CancellationToken cancellationToken)
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == command.Id);

        if (todo is null) throw new Exception($"todo {command.Id} not found");

        todo.Complete();

        _context.Todos.Entry(todo);

        var result = await _context.SaveChangesAsync();

        return new CompleteTodoResponse(
            todo.Id,
            todo.Name,
            todo.CompletedAt.GetValueOrDefault(),
            todo.Status);
    }
}
