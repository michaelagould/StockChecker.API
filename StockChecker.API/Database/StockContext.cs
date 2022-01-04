using Microsoft.EntityFrameworkCore;
using StockChecker.API.Models;

namespace StockChecker.API.Database
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
