using Microsoft.EntityFrameworkCore;
using CqrsMediatRDemo.Models;

namespace CqrsMediatRDemo.Data;

public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
     
    public DbSet<Product> Products => Set<Product>();
}
