using Microsoft.EntityFrameworkCore;
namespace SalesWebMvc.Data;

public class SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options) : DbContext(options)
{
    public DbSet<SalesWebMvc.Models.Department> Department { get; set; } = default!;
}
