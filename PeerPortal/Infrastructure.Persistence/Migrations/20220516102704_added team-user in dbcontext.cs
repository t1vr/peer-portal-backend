using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class addedteamuserindbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamUser_AspNetUsers_ApplicationUserId",
                table: "TeamUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUser_Teams_TeamId",
                table: "TeamUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamUser",
                table: "TeamUser");

            migrationBuilder.RenameTable(
                name: "TeamUser",
                newName: "TeamUsers");

            migrationBuilder.RenameIndex(
                name: "IX_TeamUser_TeamId",
                table: "TeamUsers",
                newName: "IX_TeamUsers_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamUsers",
                table: "TeamUsers",
                columns: new[] { "ApplicationUserId", "TeamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_AspNetUsers_ApplicationUserId",
                table: "TeamUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Teams_TeamId",
                table: "TeamUsers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_AspNetUsers_ApplicationUserId",
                table: "TeamUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Teams_TeamId",
                table: "TeamUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamUsers",
                table: "TeamUsers");

            migrationBuilder.RenameTable(
                name: "TeamUsers",
                newName: "TeamUser");

            migrationBuilder.RenameIndex(
                name: "IX_TeamUsers_TeamId",
                table: "TeamUser",
                newName: "IX_TeamUser_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamUser",
                table: "TeamUser",
                columns: new[] { "ApplicationUserId", "TeamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUser_AspNetUsers_ApplicationUserId",
                table: "TeamUser",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUser_Teams_TeamId",
                table: "TeamUser",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
