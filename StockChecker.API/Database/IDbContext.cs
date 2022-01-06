using Microsoft.EntityFrameworkCore;
using StockChecker.API.Models;

namespace StockChecker.API.Database
{
    public interface IDbContext 
    {
        DbSet<Product> Products { get; set; }
        public void SaveChanges();
    }
}
