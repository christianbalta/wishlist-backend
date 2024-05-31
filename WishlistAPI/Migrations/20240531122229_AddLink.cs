using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WishlistAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "wishlist");
            
            migrationBuilder.AddColumn<string>(
                name: "Link",
                schema: "wishlist",
                table: "WishlistItems",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                schema: "wishlist",
                table: "WishlistItems");
        }
    }
}
