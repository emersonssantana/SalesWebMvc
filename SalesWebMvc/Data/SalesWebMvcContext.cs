using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data;

public class SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options) : DbContext(options)
{
    public DbSet<Department> Department { get; set; } = default!;
    public DbSet<Seller> Seller { get; set; } = default!;
    public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Enforce referential integrity: restrict deleting a seller that has sales records
        modelBuilder.Entity<SalesRecord>()
            .HasOne(s => s.Seller)
            .WithMany(s => s.Sales)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

