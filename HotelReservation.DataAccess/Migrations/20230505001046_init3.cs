using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.DataAccess.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricings_Hotels_HotelId",
                table: "Pricings");

            migrationBuilder.DropIndex(
                name: "IX_Pricings_HotelId",
                table: "Pricings");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Pricings");

            migrationBuilder.RenameColumn(
                name: "ISConfirmed",
                table: "Services",
                newName: "IsConfirmed");

            migrationBuilder.RenameColumn(
                name: "ISConfirmed",
                table: "SendMails",
                newName: "IsConfirmed");

            migrationBuilder.RenameColumn(
                name: "ISConfirmed",
                table: "Reservations",
                newName: "IsConfirmed");

            migrationBuilder.RenameColumn(
                name: "ISConfirmed",
                table: "ProfileImages",
                newName: "IsConfirmed");

            migrationBuilder.RenameColumn(
                name: "ISConfirmed",
                table: "Pricings",
                newName: "IsConfirmed");

            migrationBuilder.RenameColumn(
                name: "ISConfirmed",
                table: "Pictures",
                newName: "IsConfirmed");

            migrationBuilder.RenameColumn(
                name: "ISConfirmed",
                table: "Hotels",
                newName: "IsConfirmed");

            migrationBuilder.RenameColumn(
                name: "ISConfirmed",
                table: "Guides",
                newName: "IsConfirmed");

            migrationBuilder.RenameColumn(
                name: "ISConfirmed",
                table: "ExceptionLoggers",
                newName: "IsConfirmed");

            migrationBuilder.RenameColumn(
                name: "ISConfirmed",
                table: "Contacts",
                newName: "IsConfirmed");

            migrationBuilder.RenameColumn(
                name: "ISConfirmed",
                table: "Comment",
                newName: "IsConfirmed");

            migrationBuilder.RenameColumn(
                name: "ISConfirmed",
                table: "Audits",
                newName: "IsConfirmed");

            migrationBuilder.RenameColumn(
                name: "ISConfirmed",
                table: "Abouts",
                newName: "IsConfirmed");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "SendMails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ProfileImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Pricings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Pictures",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Hotels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Guides",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ExceptionLoggers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Comment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Audits",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Abouts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hit",
                table: "Abouts",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "SendMails");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ProfileImages");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Pricings");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Guides");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ExceptionLoggers");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Hit",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "Services",
                newName: "ISConfirmed");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "SendMails",
                newName: "ISConfirmed");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "Reservations",
                newName: "ISConfirmed");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "ProfileImages",
                newName: "ISConfirmed");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "Pricings",
                newName: "ISConfirmed");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "Pictures",
                newName: "ISConfirmed");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "Hotels",
                newName: "ISConfirmed");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "Guides",
                newName: "ISConfirmed");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "ExceptionLoggers",
                newName: "ISConfirmed");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "Contacts",
                newName: "ISConfirmed");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "Comment",
                newName: "ISConfirmed");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "Audits",
                newName: "ISConfirmed");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "Abouts",
                newName: "ISConfirmed");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Pricings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_HotelId",
                table: "Pricings",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pricings_Hotels_HotelId",
                table: "Pricings",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }
    }
}
