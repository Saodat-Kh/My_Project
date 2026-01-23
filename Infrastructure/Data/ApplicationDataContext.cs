using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : DbContext(options)
{
    public DbSet<Teachers>  Teachers { get; set; }
    public DbSet<Courses>  Courses { get; set; }
    public DbSet<Groups>  Groups { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentGroups> StudentGroups { get; set; }
}