using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTelNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDepartmant = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "TaskWorks",
                columns: table => new
                {
                    TaskWorkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskWorkTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskWorkContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskWorkDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskWorkDepTopic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskWorkPriority = table.Column<int>(type: "int", nullable: false),
                    TaskWorkStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskWorkEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskWorkStatus = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskWorks", x => x.TaskWorkID);
                    table.ForeignKey(
                        name: "FK_TaskWorks_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskWorks_UserID",
                table: "TaskWorks",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskWorks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
