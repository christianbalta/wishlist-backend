namespace WishlistAPI.Models;

public class WishlistItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public bool IsReserved { get; set; }
    public string Link { get; set; }
    public string ImageLink { get; set; }
}