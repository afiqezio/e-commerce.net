using FlutterAPI.Data;
using FlutterAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlutterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShopsController : ControllerBase
    {
        private readonly FlutterDbContext _context;

        public ShopsController(FlutterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShops()
        {
            return await _context.Shops.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> GetShop(int id)
        {
            var shop = await _context.Shops.FindAsync(id);

            if (shop == null)
            {
                return NotFound();
            }

            return shop;
        }

        [HttpPost]
        public async Task<ActionResult<Shop>> CreateShop(Shop shop)
        {
            _context.Shops.Add(shop);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetShop), new { id = shop.ShopID }, shop);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShop(Guid id, Shop shop)
        {
            if (id != shop.ShopID)
            {
                return BadRequest();
            }

            _context.Entry(shop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Shops.Any(e => e.ShopID == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            var shop = await _context.Shops.FindAsync(id);

            if (shop == null)
            {
                return NotFound();
            }

            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
