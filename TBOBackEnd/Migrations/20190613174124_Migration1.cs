using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TBOBackEnd.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AdminRoles_AdminRoleId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_AdminRoleId",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "AdminRoleId",
                table: "Admins",
                newName: "AdminAccountStatusId");

            migrationBuilder.AlterColumn<string>(
                name: "AdminAccountStatusId",
                table: "Admins",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "AdminAccountStatusId1",
                table: "Admins",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdminAccountStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminAccountStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminAdminRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AdminId = table.Column<string>(nullable: false),
                    AdminRoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminAdminRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminAdminRole_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminAdminRole_AdminRoles_AdminRoleId",
                        column: x => x.AdminRoleId,
                        principalTable: "AdminRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AdminAccountStatusId1",
                table: "Admins",
                column: "AdminAccountStatusId1");

            migrationBuilder.CreateIndex(
                name: "IX_AdminAdminRole_AdminId",
                table: "AdminAdminRole",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminAdminRole_AdminRoleId",
                table: "AdminAdminRole",
                column: "AdminRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AdminAccountStatus_AdminAccountStatusId1",
                table: "Admins",
                column: "AdminAccountStatusId1",
                principalTable: "AdminAccountStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AdminAccountStatus_AdminAccountStatusId1",
                table: "Admins");

            migrationBuilder.DropTable(
                name: "AdminAccountStatus");

            migrationBuilder.DropTable(
                name: "AdminAdminRole");

            migrationBuilder.DropIndex(
                name: "IX_Admins_AdminAccountStatusId1",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "AdminAccountStatusId1",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "AdminAccountStatusId",
                table: "Admins",
                newName: "AdminRoleId");

            migrationBuilder.AlterColumn<string>(
                name: "AdminRoleId",
                table: "Admins",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AdminRoleId",
                table: "Admins",
                column: "AdminRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AdminRoles_AdminRoleId",
                table: "Admins",
                column: "AdminRoleId",
                principalTable: "AdminRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
