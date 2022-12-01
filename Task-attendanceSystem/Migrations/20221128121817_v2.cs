using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_attendanceSystem.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendences_AspNetUsers_ApplicationUserGuid",
                table: "Attendences");

            migrationBuilder.AddForeignKey(
                name: "ApplicationUserGuid",
                table: "Attendences",
                column: "ApplicationUserGuid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ApplicationUserGuid",
                table: "Attendences");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendences_AspNetUsers_ApplicationUserGuid",
                table: "Attendences",
                column: "ApplicationUserGuid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
