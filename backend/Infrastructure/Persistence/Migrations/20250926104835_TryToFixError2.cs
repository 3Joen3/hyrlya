using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TryToFixError2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RentalType",
                table: "Listings",
                newName: "ChargeInterval");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Listings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "ChargeInterval",
                table: "Listings",
                newName: "RentalType");
        }
    }
}
