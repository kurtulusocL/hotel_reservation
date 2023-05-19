using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.DataAccess.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Hotels_HotelId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_HotelId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Pictures");

            migrationBuilder.AddColumn<bool>(
                name: "IsReservationApproved",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReservationApproved",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Pictures",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_HotelId",
                table: "Pictures",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Hotels_HotelId",
                table: "Pictures",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }
    }
}
