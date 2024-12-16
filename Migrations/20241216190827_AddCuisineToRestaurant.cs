using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantReviewApp.Migrations
{
    /// <inheritdoc />
    public partial class AddCuisineToRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuisineType",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "Reviews",
                table: "Restaurants",
                newName: "Cuisine");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cuisine",
                table: "Restaurants",
                newName: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "CuisineType",
                table: "Restaurants",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Restaurants",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
