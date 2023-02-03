using ABS_Insurance.Model;
using Microsoft.EntityFrameworkCore;

namespace ABS_Insurance.Data.AppDBContext;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)  
    {  

    } 
    
    public DbSet<Policy> Policies { get; set; }  
    public DbSet<Components> Components { get; set; }
}