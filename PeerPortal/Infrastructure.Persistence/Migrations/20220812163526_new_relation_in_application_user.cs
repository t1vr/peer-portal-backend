using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class new_relation_in_application_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberRoles",
                table: "MemberRoles");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "MemberRoles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberRoles",
                table: "MemberRoles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRoles_TeamUserId",
                table: "MemberRoles",
                column: "TeamUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberRoles",
                table: "MemberRoles");

            migrationBuilder.DropIndex(
                name: "IX_MemberRoles_TeamUserId",
                table: "MemberRoles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MemberRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberRoles",
                table: "MemberRoles",
                columns: new[] { "TeamUserId", "ApplicationRoleId" });
        }
    }
}
