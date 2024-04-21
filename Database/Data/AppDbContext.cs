using Database.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Aluno> Aluno { get; set; }
    public DbSet<Endereco> Endereco { get; set; }
}

