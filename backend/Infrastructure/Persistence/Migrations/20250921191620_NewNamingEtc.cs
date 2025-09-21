using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewNamingEtc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactPhone",
                table: "LandlordProfiles",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "ContactEmail",
                table: "LandlordProfiles",
                newName: "EmailAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "LandlordProfiles",
                newName: "ContactPhone");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "LandlordProfiles",
                newName: "ContactEmail");
        }
    }
}
