using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contact.Data.Migrations
{
    public partial class _020120222015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Contacts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Contacts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Contacts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Contacts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "ContactDetails",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "ContactDetails",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ContactDetails",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ContactDetails",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ContactDetails");
        }
    }
}
