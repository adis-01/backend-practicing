using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practice.Services.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertiesKorisnici : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.AddColumn<bool>("isActive","Korisnici",nullable:false,defaultValue:false);
           migrationBuilder.AddColumn<string>("Email", "Korisnici", nullable: false, defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("isActive", "Korisnici");
            migrationBuilder.DropColumn("Email", "Korisnici");
        }
    }
}
