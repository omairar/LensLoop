using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class smallupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_LLUser_Id",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Post",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Post_Id",
                table: "Post",
                newName: "IX_Post_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_LLUser_user_id",
                table: "Post",
                column: "user_id",
                principalTable: "LLUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_LLUser_user_id",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Post",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Post_user_id",
                table: "Post",
                newName: "IX_Post_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_LLUser_Id",
                table: "Post",
                column: "Id",
                principalTable: "LLUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
