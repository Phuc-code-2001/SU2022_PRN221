using Microsoft.EntityFrameworkCore.Migrations;

namespace ShinyTeeth.Migrations
{
    public partial class UpdateApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomCode",
                table: "Appointments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Appointments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RoomCode",
                table: "Appointments",
                column: "RoomCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Rooms_RoomCode",
                table: "Appointments",
                column: "RoomCode",
                principalTable: "Rooms",
                principalColumn: "RoomCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Rooms_RoomCode",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_RoomCode",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "RoomCode",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Appointments");
        }
    }
}
