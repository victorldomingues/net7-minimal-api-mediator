using TodoApi.ValueObjects;

namespace TodoApi.Models.Responses;

public record DeleteTodoResponse
(
    Guid Id,
    string Name,
    DateTime DeletedAt,
    Status status
);
