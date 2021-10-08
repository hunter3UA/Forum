using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.DAL.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Topics_TopicID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TopicID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TopicID",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "TopicUser",
                columns: table => new
                {
                    UserTopicsTopicID = table.Column<long>(type: "bigint", nullable: false),
                    UsersUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicUser", x => new { x.UserTopicsTopicID, x.UsersUserID });
                    table.ForeignKey(
                        name: "FK_TopicUser_Topics_UserTopicsTopicID",
                        column: x => x.UserTopicsTopicID,
                        principalTable: "Topics",
                        principalColumn: "TopicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicUser_Users_UsersUserID",
                        column: x => x.UsersUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicUser_UsersUserID",
                table: "TopicUser",
                column: "UsersUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicUser");

            migrationBuilder.AddColumn<long>(
                name: "TopicID",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TopicID",
                table: "Users",
                column: "TopicID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Topics_TopicID",
                table: "Users",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "TopicID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
