using System.ComponentModel.DataAnnotations.Schema;
using TodoApi.ValueObjects;

namespace TodoApi.Models.Entities;

public class Todo
{
    protected Todo() { }

    public Todo(string name)
    {
        Name = name;
        Status = Status.Created;
        CreatedAt = DateTime.Now;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    public void Update(string name)
    {
        Name = name;
        Status = Status.Updated;
        UpdatedAt = DateTime.Now;
    }

    public void Complete()
    {
        Status = Status.Completed;
        CompletedAt = UpdatedAt;
    }

    public void Delete()
    {
        Status = Status.Deleted;
        DeletedAt = DateTime.Now;
    }
}
