using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Infrastructure.Persistence.Migrations
{
    public partial class AddRentalState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Rentals");
        }
    }
}
