using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class compositekeyremovedfromTeamUsertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamUsers",
                table: "TeamUsers");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "TeamUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Teams",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamUsers",
                table: "TeamUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeamUsers_ApplicationUserId",
                table: "TeamUsers",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamUsers",
                table: "TeamUsers");

            migrationBuilder.DropIndex(
                name: "IX_TeamUsers_ApplicationUserId",
                table: "TeamUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TeamUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Teams",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamUsers",
                table: "TeamUsers",
                columns: new[] { "ApplicationUserId", "TeamId" });
        }
    }
}
