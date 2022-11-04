using Microsoft.EntityFrameworkCore.Migrations;

namespace VeiculosApp.Infra.Repositories.EF.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleImages_Vehicles_IdVehicle",
                table: "VehicleImages");

            migrationBuilder.AlterColumn<int>(
                name: "IdVehicle",
                table: "VehicleImages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleImages_Vehicles_IdVehicle",
                table: "VehicleImages",
                column: "IdVehicle",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleImages_Vehicles_IdVehicle",
                table: "VehicleImages");

            migrationBuilder.AlterColumn<int>(
                name: "IdVehicle",
                table: "VehicleImages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleImages_Vehicles_IdVehicle",
                table: "VehicleImages",
                column: "IdVehicle",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
