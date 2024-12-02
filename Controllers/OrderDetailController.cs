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
    public class OrderDetailController : ControllerBase
    {
        private readonly FlutterDbContext _context;

        public OrderDetailController(FlutterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetail()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(Guid id)
        {
            var OrderDetail = await _context.OrderDetails.FindAsync(id);

            if (OrderDetail == null)
            {
                return NotFound();
            }

            return OrderDetail;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDetail>> CreateOrderDetail(OrderDetail OrderDetail)
        {
            _context.OrderDetails.Add(OrderDetail);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrderDetail), new { id = OrderDetail.OrderDetailID }, OrderDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(Guid id, OrderDetail OrderDetail)
        {
            if (id != OrderDetail.OrderDetailID)
            {
                return BadRequest();
            }

            _context.Entry(OrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.OrderDetails.Any(e => e.OrderDetailID == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(Guid id)
        {
            var OrderDetail = await _context.OrderDetails.FindAsync(id);

            if (OrderDetail == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(OrderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
