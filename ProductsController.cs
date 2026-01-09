using gq_kp_api.Data;
using gq_kp_api.Dto;
using gq_kp_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gq_kp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        /* v1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            // Include Brand info
            return await _context.Products
                                 .Include(p => p.Brand)
                                 .ToListAsync();
        }
        */
        // v2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _context.Products
                .Include(p => p.Brand)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    BrandId = p.BrandId,
                    BrandName = p.Brand.BrandName,
                    SkuCode = p.SkuCode,
                    AgskCode = p.AgskCode,
                    ProductName = p.ProductName,
                    Uom = p.UoM,
                    PriceExVat = p.PriceExVat,
                    PriceIncVat = p.PriceIncVat                    
                })
                .ToListAsync();

            return Ok(products);
        }

        // GET: api/products/5
        /* v1
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products
                                        .Include(p => p.Brand)
                                        .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            return product;
        }
        */
        // v2
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Brand)
                .Where(p => p.Id == id)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    BrandId = p.BrandId,
                    BrandName = p.Brand.BrandName,
                    SkuCode = p.SkuCode,
                    AgskCode = p.AgskCode,
                    ProductName = p.ProductName,
                    Uom = p.UoM,
                    PriceExVat = p.PriceExVat,
                    PriceIncVat = p.PriceIncVat                    
                })
                .FirstOrDefaultAsync();

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // GET /api/products/search?q=iphone
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> SearchProducts([FromQuery] string q)
        {
            if (string.IsNullOrWhiteSpace(q))
                return BadRequest("Query parameter 'q' is required.");

            q = q.Trim().ToLower();
            /*
            var products = await _context.Products
                .Include(p => p.Brand)
                .Where(p =>
                    (p.SkuCode != null && EF.Functions.ILike(p.SkuCode, $"%{q}%")) ||
                    (p.AgskCode != null && EF.Functions.ILike(p.AgskCode, $"%{q}%")) ||
                    (p.ProductName != null && EF.Functions.ILike(p.ProductName, $"%{q}%"))
                )
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    BrandId = p.BrandId,
                    BrandName = p.Brand.BrandName,
                    SkuCode = p.SkuCode,
                    AgskCode = p.AgskCode,
                    ProductName = p.ProductName,
                    PriceExVat = p.PriceExVat,
                    PriceIncVat = p.PriceIncVat,
                    Uom = p.UoM
                })
                .ToListAsync();
            */

            var products = await _context.Products
                .Include(p => p.Brand)
                .Where(p =>
                    (p.SkuCode != null && EF.Functions.ILike(p.SkuCode.ToLower(), $"%{q.ToLower()}%")) ||
                    (p.AgskCode != null && EF.Functions.ILike(p.AgskCode.ToLower(), $"%{q.ToLower()}%")) ||
                    (p.ProductName != null && EF.Functions.ILike(p.ProductName.ToLower(), $"%{q.ToLower()}%"))
                )
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    BrandId = p.BrandId,
                    BrandName = p.Brand.BrandName,
                    SkuCode = p.SkuCode,
                    AgskCode = p.AgskCode,
                    ProductName = p.ProductName,
                    PriceExVat = p.PriceExVat,
                    PriceIncVat = p.PriceIncVat,
                    Uom = p.UoM
                })
                .ToListAsync();

            return Ok(products);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            // Optional: check if BrandId exists
            var brandExists = await _context.Brands.AnyAsync(b => b.Id == product.BrandId);
            if (!brandExists)
                return BadRequest($"Brand with ID {product.BrandId} does not exist.");

            var productExists = await _context.Products.AnyAsync(p => 
                p.BrandId == product.BrandId &&
                p.SkuCode == product.SkuCode &&
                p.AgskCode == product.AgskCode
            );
            
            if (productExists)
                return Ok(product);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
