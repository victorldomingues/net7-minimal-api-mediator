using TodoApi.ValueObjects;

namespace TodoApi.Models.Responses;

public record CreateTodoResponse
(
    Guid Id,
    string Name,
    DateTime CreatedAt,
    Status Status
);
