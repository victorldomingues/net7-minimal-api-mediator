using TodoApi.Models.Responses;
using MediatR;

namespace TodoApi.Models.Commands;

public record CompleteTodoCommand(Guid Id) : IRequest<CompleteTodoResponse>;
