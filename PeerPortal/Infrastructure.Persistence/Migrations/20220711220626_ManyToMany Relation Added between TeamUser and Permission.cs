using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class ManyToManyRelationAddedbetweenTeamUserandPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionTeamUser",
                columns: table => new
                {
                    PermissionsId = table.Column<string>(type: "text", nullable: false),
                    TeamUsersId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionTeamUser", x => new { x.PermissionsId, x.TeamUsersId });
                    table.ForeignKey(
                        name: "FK_PermissionTeamUser_Permissions_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionTeamUser_TeamUsers_TeamUsersId",
                        column: x => x.TeamUsersId,
                        principalTable: "TeamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionTeamUser_TeamUsersId",
                table: "PermissionTeamUser",
                column: "TeamUsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionTeamUser");
        }
    }
}
