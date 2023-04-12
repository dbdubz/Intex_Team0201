using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class DbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "depth",
                table: "burialmain");

            migrationBuilder.DropColumn(
                name: "length",
                table: "burialmain");

            migrationBuilder.AddColumn<string>(
                name: "burialdepth",
                table: "burialmain",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "buriallength",
                table: "burialmain",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "burialdepth",
                table: "burialmain");

            migrationBuilder.DropColumn(
                name: "buriallength",
                table: "burialmain");

            migrationBuilder.AddColumn<string>(
                name: "depth",
                table: "burialmain",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "length",
                table: "burialmain",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
