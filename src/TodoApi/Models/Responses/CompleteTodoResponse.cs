using TodoApi.ValueObjects;

namespace TodoApi.Models.Responses;

public record CompleteTodoResponse
(
    Guid Id,
    string Name,
    DateTime CompletedAt,
    Status Status
);
