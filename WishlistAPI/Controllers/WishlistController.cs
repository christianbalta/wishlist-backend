using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WishlistAPI.Data;
using WishlistAPI.Models;

namespace WishlistAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WishlistController : ControllerBase
{
    private readonly DataContext _context;

    public WishlistController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WishlistItem>>> GetWishlistItems()
    {
        var items = await _context.WishlistItems.OrderBy(item => item.Name).ToListAsync();

        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WishlistItem>> GetWishlistItem(int id)
    {
        var item = await _context.WishlistItems.FindAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        return item;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutWishlistItem(int id, WishlistItem item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        _context.Entry(item).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.WishlistItems.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }
}