using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class MemberRoletableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberRoles",
                columns: table => new
                {
                    TeamUserId = table.Column<string>(type: "text", nullable: false),
                    IdentityRoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRoles", x => new { x.TeamUserId, x.IdentityRoleId });
                    table.ForeignKey(
                        name: "FK_MemberRoles_AspNetRoles_IdentityRoleId",
                        column: x => x.IdentityRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberRoles_TeamUsers_TeamUserId",
                        column: x => x.TeamUserId,
                        principalTable: "TeamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberRoles_IdentityRoleId",
                table: "MemberRoles",
                column: "IdentityRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberRoles");
        }
    }
}
