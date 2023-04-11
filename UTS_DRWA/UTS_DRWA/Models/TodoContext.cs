using Microsoft.EntityFrameworkCore;

namespace UTS_DRWA.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<Todoguru> Todoguru { get; set; } = null!;
    public DbSet<Todomapel> Todomapel { get; set; } = null!;
    public DbSet<jadwalguru> jadwalguru { get; set; } = null!;
}