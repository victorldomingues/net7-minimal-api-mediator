using TodoApi.Models.Responses;
using MediatR;

namespace TodoApi.Models.Commands;

public record CreateTodoCommand(string Name) : IRequest<CreateTodoResponse>;
