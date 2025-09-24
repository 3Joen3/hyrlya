using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialListing2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Landlords_LandlordId",
                table: "Listing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listing",
                table: "Listing");

            migrationBuilder.RenameTable(
                name: "Listing",
                newName: "Listings");

            migrationBuilder.RenameIndex(
                name: "IX_Listing_LandlordId",
                table: "Listings",
                newName: "IX_Listings_LandlordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listings",
                table: "Listings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Landlords_LandlordId",
                table: "Listings",
                column: "LandlordId",
                principalTable: "Landlords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Landlords_LandlordId",
                table: "Listings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listings",
                table: "Listings");

            migrationBuilder.RenameTable(
                name: "Listings",
                newName: "Listing");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_LandlordId",
                table: "Listing",
                newName: "IX_Listing_LandlordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listing",
                table: "Listing",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Landlords_LandlordId",
                table: "Listing",
                column: "LandlordId",
                principalTable: "Landlords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
