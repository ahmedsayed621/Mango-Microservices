using Microsoft.EntityFrameworkCore;
using ProductService.API.Models;

namespace ProductService.API.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
    }
}
