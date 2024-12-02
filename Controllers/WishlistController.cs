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
    public class WishlistController : ControllerBase
    {
        private readonly FlutterDbContext _context;

        public WishlistController(FlutterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlist()
        {
            return await _context.Wishlist.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> GetWishlist(Guid id)
        {
            var wishlist = await _context.Wishlist.FindAsync(id);

            if (wishlist == null)
            {
                return NotFound();
            }

            return wishlist;
        }

        [HttpPost]
        public async Task<ActionResult<Wishlist>> CreateWishlist(Wishlist wishlist)
        {
            _context.Wishlist.Add(wishlist);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWishlist), new { id = wishlist.WishlistID }, wishlist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWishlist(Guid id, Wishlist wishlist)
        {
            if (id != wishlist.WishlistID)
            {
                return BadRequest();
            }

            _context.Entry(wishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Wishlist.Any(e => e.WishlistID == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(Guid id)
        {
            var wishlist = await _context.Wishlist.FindAsync(id);

            if (wishlist == null)
            {
                return NotFound();
            }

            _context.Wishlist.Remove(wishlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
