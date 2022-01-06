using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockChecker.API.Database;
using StockChecker.API.Models;

namespace StockChecker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockContext _dbContext;

        public StockController(StockContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public string Get()
        {
            return "test";
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _dbContext.Products.FirstOrDefault(a => a.Id == id);
            if(product == null) return NotFound();
            return Ok(product.StockCount);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] int stockCount)
        {
            Product product = _dbContext.Products.FirstOrDefault(a => a.Id == id);
            if (product == null) return NotFound();
            product.StockCount = stockCount;
            _dbContext.SaveChanges();
            return Ok(product.StockCount);
        }
    }
}
