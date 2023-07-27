namespace Tempo_Backend.Data;

using Microsoft.EntityFrameworkCore;
using Tempo_Backend.Models.User;

public class DataContext : DbContext
{
    public DataContext()
    {
    }
    public DbSet<User> users { get; set; }

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlServer("A FALLBACK CONNECTION STRING");
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().ToTable("users");
    }

}