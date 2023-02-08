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
        modelBuilder.Entity<Components>()
            .HasKey(c => c.ComponentsId);
        modelBuilder.Entity<Components>()
            .HasOne<Policy>(e => e.Policy)
            .WithMany(g => g.ComponentsList)
            .HasForeignKey(s => s.Pol_Id);

    } 
    
    public DbSet<Policy> Policies { get; set; }  
    public DbSet<Components> Components { get; set; }
}