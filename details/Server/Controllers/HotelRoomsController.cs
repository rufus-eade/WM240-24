using details.Server.Data;
using details.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace details.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelRoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // api/HotelRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms()
        {
            return await _context.HotelRooms.ToListAsync();
        }

        // api/HotelRooms/id using hotel room id
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int id)
        {
            var hotelRoom = await _context.HotelRooms.FindAsync(id);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // add to cart from hotel room id 
        [HttpPost("AddToCart/{id}")]
        public async Task<IActionResult> AddToCart(int id)
        {
            var hotelRoom = await _context.HotelRooms.FindAsync(id);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            var cartItem = new ShoppingCartItem
            {
                HotelRoomId = hotelRoom.RoomId,
                HotelRoom = hotelRoom,
                Quantity = 1
            };

            _context.ShoppingCartItems.Add(cartItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpGet("ShoppingCart")]
        //public async Task<List<ShoppingCartItem>> GetShoppingCart()
        //{
        //    return await _context.ShoppingCartItems.ToListAsync();
        //}
        [HttpGet("ShoppingCart")]
        public async Task<ActionResult<IEnumerable<ShoppingCartItem>>> GetShoppingCart()
        {
            return await _context.ShoppingCartItems.Include(item => item.HotelRoom).ToListAsync();
        }

        [HttpDelete("RemoveFromCart/{id}")]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var cartItem = await _context.ShoppingCartItems.FindAsync(id);

            if (cartItem == null)
            {
                return NotFound();
            }

            _context.ShoppingCartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}