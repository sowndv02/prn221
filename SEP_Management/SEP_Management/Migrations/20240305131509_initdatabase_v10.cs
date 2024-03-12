using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEP_Management.Migrations
{
    public partial class initdatabase_v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_system_setting_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "system_setting");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Roles",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Roles");

            migrationBuilder.CreateTable(
                name: "system_setting",
                columns: table => new
                {
                    setting_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    display_order = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<byte>(type: "tinyint", nullable: true),
                    setting_group = table.Column<int>(type: "int", nullable: false),
                    setting_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_system_setting", x => x.setting_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_system_setting_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "system_setting",
                principalColumn: "setting_id");
        }
    }
}
