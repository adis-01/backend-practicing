using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practice.Services.Migrations
{
    /// <inheritdoc />
    public partial class SaltAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VerifikacijskiTokenSalt",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerifikacijskiTokenSalt",
                table: "Korisnici");
        }
    }
}
