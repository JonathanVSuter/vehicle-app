using Microsoft.EntityFrameworkCore.Migrations;

namespace VeiculosApp.Infra.Repositories.EF.Migrations
{
    public partial class AddAnnouncementValueToAnnoucement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AnnouncedValue",
                table: "Announcement",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnouncedValue",
                table: "Announcement");
        }
    }
}
