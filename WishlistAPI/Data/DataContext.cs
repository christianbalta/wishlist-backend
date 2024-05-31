using Microsoft.EntityFrameworkCore;
using WishlistAPI.Models;

namespace WishlistAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<WishlistItem> WishlistItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("wishlist");
    }
}