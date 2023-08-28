using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngerTravelTours.Migrations
{
    public partial class fourthmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stars",
                table: "TourPackages",
                newName: "Rating");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "TourPackages",
                newName: "Stars");
        }
    }
}
