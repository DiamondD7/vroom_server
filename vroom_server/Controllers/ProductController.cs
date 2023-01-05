using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vroom_server.Data;
using vroom_server.Model;

namespace vroom_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductsById(int id)
        {
            var findId = await _context.Products.FindAsync(id);
            if(findId == null)
            {
                return NotFound();
            }
            return findId;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if(id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return Ok("Updated");
            
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllProducts", new { id = products.Id }, products);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var findId = await _context.Products.FindAsync(id);
            if(findId == null)
            {
                return NotFound();
            }
            _context.Products.Remove(findId);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }
        
    }
}
