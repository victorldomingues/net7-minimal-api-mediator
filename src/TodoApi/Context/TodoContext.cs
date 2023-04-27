using TodoApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Context;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options) { }

    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>()
                    .Property(x => x.Name)
                    .IsRequired();

        modelBuilder.Entity<Todo>()
                    .Property(x => x.CreatedAt)
                    .IsRequired();

        modelBuilder.Entity<Todo>()
                    .HasKey(x => x.Id);
    }
}
