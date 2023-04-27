using TodoApi.Models.Responses;
using MediatR;

namespace TodoApi.Models.Commands;

public record UpdateTodoCommand(Guid Id, string Name) 
    : IRequest<UpdateTodoResponse>;
