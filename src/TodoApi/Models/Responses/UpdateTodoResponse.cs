using TodoApi.ValueObjects;

namespace TodoApi.Models.Responses;

public record UpdateTodoResponse
(
    Guid Id,
    string Name,
    DateTime UpdatedAt,
    Status status
);

