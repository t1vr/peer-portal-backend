using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class TwoWayNavigationPropertyAddedforMemberRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberRoles_AspNetRoles_IdentityRoleId",
                table: "MemberRoles");

            migrationBuilder.RenameColumn(
                name: "IdentityRoleId",
                table: "MemberRoles",
                newName: "ApplicationRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_MemberRoles_IdentityRoleId",
                table: "MemberRoles",
                newName: "IX_MemberRoles_ApplicationRoleId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberRoles_AspNetRoles_ApplicationRoleId",
                table: "MemberRoles",
                column: "ApplicationRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberRoles_AspNetRoles_ApplicationRoleId",
                table: "MemberRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.RenameColumn(
                name: "ApplicationRoleId",
                table: "MemberRoles",
                newName: "IdentityRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_MemberRoles_ApplicationRoleId",
                table: "MemberRoles",
                newName: "IX_MemberRoles_IdentityRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberRoles_AspNetRoles_IdentityRoleId",
                table: "MemberRoles",
                column: "IdentityRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
