using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_attendanceSystem.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAbsented",
                table: "Attendences",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAttended",
                table: "Attendences",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelayed",
                table: "Attendences",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAbsented",
                table: "Attendences");

            migrationBuilder.DropColumn(
                name: "IsAttended",
                table: "Attendences");

            migrationBuilder.DropColumn(
                name: "IsDelayed",
                table: "Attendences");
        }
    }
}
