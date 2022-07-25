using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_project.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_UserDB_user_id",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_user_id",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_user_id",
                table: "Posts",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_UserDB_user_id",
                table: "Posts",
                column: "user_id",
                principalTable: "UserDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
