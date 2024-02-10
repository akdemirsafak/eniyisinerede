using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.API.Migrations
{
    /// <inheritdoc />
    public partial class PlaceIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Reservations",
                newName: "PlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlaceId",
                table: "Reservations",
                newName: "RestaurantId");
        }
    }
}
