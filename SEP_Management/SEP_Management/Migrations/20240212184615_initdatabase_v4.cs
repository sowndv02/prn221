using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEP_Management.Migrations
{
    public partial class initdatabase_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "system_setting",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "system_setting",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "subject_setting",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "subject_setting",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "subject",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "subject",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "project",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "project",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "milestone",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "milestone",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "issue_update",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "issue_update",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "issue_setting",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "issue_setting",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "issue",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "issue",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "class_student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "class_student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "class",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "class",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "assignment",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "assignment",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "system_setting");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "system_setting");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "subject_setting");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "subject_setting");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "subject");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "subject");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "project");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "project");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "milestone");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "milestone");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "issue_update");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "issue_update");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "issue_setting");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "issue_setting");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "issue");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "issue");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "class_student");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "class_student");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "class");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "class");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "assignment");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "assignment");
        }
    }
}
