using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedFkRoleIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FkRoleId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FkRoleId",
                table: "Users",
                column: "FkRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_FkRoleId",
                table: "Users",
                column: "FkRoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_FkRoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FkRoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FkRoleId",
                table: "Users");
        }
    }
}
