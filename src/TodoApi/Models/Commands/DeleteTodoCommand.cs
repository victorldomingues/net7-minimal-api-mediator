using TodoApi.Models.Responses;
using MediatR;

namespace TodoApi.Models.Commands;

public record DeleteTodoCommand(Guid Id) : IRequest<DeleteTodoResponse>;
