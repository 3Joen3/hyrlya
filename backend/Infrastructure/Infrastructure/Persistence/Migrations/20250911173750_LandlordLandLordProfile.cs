using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LandlordLandLordProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdentityId",
                table: "Landlords",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "LandlordProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageAlt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandlordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandlordProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandlordProfiles_Landlords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Landlords_IdentityId",
                table: "Landlords",
                column: "IdentityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LandlordProfiles_LandlordId",
                table: "LandlordProfiles",
                column: "LandlordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Landlords_AspNetUsers_IdentityId",
                table: "Landlords",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Landlords_AspNetUsers_IdentityId",
                table: "Landlords");

            migrationBuilder.DropTable(
                name: "LandlordProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Landlords_IdentityId",
                table: "Landlords");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityId",
                table: "Landlords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
