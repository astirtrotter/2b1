using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TBOBackEnd.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminAccountStatuses",
                columns: table => new
                {
                    AccountStatus = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminAccountStatuses", x => x.AccountStatus);
                });

            migrationBuilder.CreateTable(
                name: "AdminPermissions",
                columns: table => new
                {
                    Permission = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminPermissions", x => x.Permission);
                });

            migrationBuilder.CreateTable(
                name: "AdminRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    AdminAccountStatusId = table.Column<int>(nullable: false),
                    LastAccessedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AdminAccountStatuses_AdminAccountStatusId",
                        column: x => x.AdminAccountStatusId,
                        principalTable: "AdminAccountStatuses",
                        principalColumn: "AccountStatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminRolePermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdminRoleId = table.Column<string>(nullable: false),
                    AdminPermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminRolePermission_AdminPermissions_AdminPermissionId",
                        column: x => x.AdminPermissionId,
                        principalTable: "AdminPermissions",
                        principalColumn: "Permission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminRolePermission_AdminRoles_AdminRoleId",
                        column: x => x.AdminRoleId,
                        principalTable: "AdminRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminActivities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AdminId = table.Column<string>(nullable: false),
                    Action = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminActivities_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "AdminTokens",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AdminId = table.Column<string>(nullable: false),
                    LastAccessedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminTokens_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminActivities_AdminId",
                table: "AdminActivities",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminAdminRole_AdminId",
                table: "AdminAdminRole",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminAdminRole_AdminRoleId",
                table: "AdminAdminRole",
                column: "AdminRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminRolePermission_AdminPermissionId",
                table: "AdminRolePermission",
                column: "AdminPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminRolePermission_AdminRoleId",
                table: "AdminRolePermission",
                column: "AdminRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AdminAccountStatusId",
                table: "Admins",
                column: "AdminAccountStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminTokens_AdminId",
                table: "AdminTokens",
                column: "AdminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminActivities");

            migrationBuilder.DropTable(
                name: "AdminAdminRole");

            migrationBuilder.DropTable(
                name: "AdminRolePermission");

            migrationBuilder.DropTable(
                name: "AdminTokens");

            migrationBuilder.DropTable(
                name: "AdminPermissions");

            migrationBuilder.DropTable(
                name: "AdminRoles");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AdminAccountStatuses");
        }
    }
}
