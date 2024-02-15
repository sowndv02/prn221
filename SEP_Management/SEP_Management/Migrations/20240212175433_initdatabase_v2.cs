using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEP_Management.Migrations
{
    public partial class initdatabase_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    class_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    class_details = table.Column<string>(type: "text", nullable: true),
                    semester_id = table.Column<int>(type: "int", nullable: true),
                    subject_id = table.Column<int>(type: "int", nullable: true),
                    manager_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: true),
                    created_by = table.Column<short>(type: "smallint", nullable: true),
                    created_at = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    updated_by = table.Column<short>(type: "smallint", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    gitlab_id = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    access_token = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.class_id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    subject_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<byte>(type: "tinyint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    time_allocation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    pass_grade = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.subject_id);
                });

            migrationBuilder.CreateTable(
                name: "system_setting",
                columns: table => new
                {
                    setting_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    setting_group = table.Column<int>(type: "int", nullable: false),
                    setting_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    display_order = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<byte>(type: "tinyint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_system_setting", x => x.setting_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "class_student",
                columns: table => new
                {
                    class_st_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_id = table.Column<int>(type: "int", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<byte>(type: "tinyint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: false),
                    created_by = table.Column<short>(type: "smallint", nullable: false),
                    created_at = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    updated_by = table.Column<short>(type: "smallint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    is_leader = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class_student", x => x.class_st_id);
                    table.ForeignKey(
                        name: "FK_class_student_class",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "class_id");
                });

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    project_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    project_en_name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    project_vie_name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    project_description = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    class_id = table.Column<int>(type: "int", nullable: true),
                    group_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    mentor_id = table.Column<int>(type: "int", nullable: true),
                    co_mentor_id = table.Column<int>(type: "int", nullable: true),
                    access_token = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.project_Id);
                    table.ForeignKey(
                        name: "FK_project_class",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "class_id");
                });

            migrationBuilder.CreateTable(
                name: "assignment",
                columns: table => new
                {
                    assign_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_id = table.Column<int>(type: "int", nullable: false),
                    assign_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    assign_description = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<byte>(type: "tinyint", nullable: false),
                    created_by = table.Column<short>(type: "smallint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<short>(type: "smallint", nullable: false),
                    updated_at = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    part = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    weight = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    due_date = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignment", x => x.assign_id);
                    table.ForeignKey(
                        name: "FK_assignment_subject",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "subject_id");
                });

            migrationBuilder.CreateTable(
                name: "subject_setting",
                columns: table => new
                {
                    setting_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    setting_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    setting_type = table.Column<int>(type: "int", nullable: true),
                    setting_value = table.Column<int>(type: "int", nullable: true),
                    subject_id = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject_setting", x => x.setting_id);
                    table.ForeignKey(
                        name: "FK_subject_setting_subject",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "subject_id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: true),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_system_setting_RoleId",
                        column: x => x.RoleId,
                        principalTable: "system_setting",
                        principalColumn: "setting_id");
                });

            migrationBuilder.CreateTable(
                name: "issue_setting",
                columns: table => new
                {
                    setting_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_id = table.Column<int>(type: "int", nullable: true),
                    class_id = table.Column<int>(type: "int", nullable: true),
                    project_id = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_active = table.Column<byte>(type: "tinyint", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issue_setting", x => x.setting_id);
                    table.ForeignKey(
                        name: "FK_issue_setting_class",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "class_id");
                    table.ForeignKey(
                        name: "FK_issue_setting_project",
                        column: x => x.project_id,
                        principalTable: "project",
                        principalColumn: "project_Id");
                    table.ForeignKey(
                        name: "FK_issue_setting_subject",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "subject_id");
                });

            migrationBuilder.CreateTable(
                name: "milestone",
                columns: table => new
                {
                    milestone_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    minestone_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    due_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_active = table.Column<byte>(type: "tinyint", nullable: true),
                    class_id = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    project_id = table.Column<int>(type: "int", nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    gitlab_id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_milestone", x => x.milestone_id);
                    table.ForeignKey(
                        name: "FK_milestone_class",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "class_id");
                    table.ForeignKey(
                        name: "FK_milestone_project",
                        column: x => x.project_id,
                        principalTable: "project",
                        principalColumn: "project_Id");
                });

            migrationBuilder.CreateTable(
                name: "assign_setting",
                columns: table => new
                {
                    setting_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assign_id = table.Column<int>(type: "int", nullable: false),
                    setting_group = table.Column<byte>(type: "tinyint", nullable: false),
                    setting_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    setting_value = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    display_order = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assign_setting", x => x.setting_id);
                    table.ForeignKey(
                        name: "FK_assign_setting_assignment",
                        column: x => x.assign_id,
                        principalTable: "assignment",
                        principalColumn: "assign_id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "issue",
                columns: table => new
                {
                    issue_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_id = table.Column<int>(type: "int", nullable: true),
                    milestone_id = table.Column<int>(type: "int", nullable: true),
                    type_id = table.Column<int>(type: "int", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    process_id = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issue", x => x.issue_id);
                    table.ForeignKey(
                        name: "FK_issue_issue_setting",
                        column: x => x.type_id,
                        principalTable: "issue_setting",
                        principalColumn: "setting_id");
                    table.ForeignKey(
                        name: "FK_issue_milestone",
                        column: x => x.milestone_id,
                        principalTable: "milestone",
                        principalColumn: "milestone_id");
                    table.ForeignKey(
                        name: "FK_issue_project",
                        column: x => x.project_id,
                        principalTable: "project",
                        principalColumn: "project_Id");
                });

            migrationBuilder.CreateTable(
                name: "issue_update",
                columns: table => new
                {
                    updated_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    issue_id = table.Column<int>(type: "int", nullable: true),
                    milestone_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issue_update", x => x.updated_id);
                    table.ForeignKey(
                        name: "FK_issue_update_issue",
                        column: x => x.issue_id,
                        principalTable: "issue",
                        principalColumn: "issue_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_assign_setting_assign_id",
                table: "assign_setting",
                column: "assign_id");

            migrationBuilder.CreateIndex(
                name: "IX_assignment_subject_id",
                table: "assignment",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_class_student_class_id",
                table: "class_student",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_issue_milestone_id",
                table: "issue",
                column: "milestone_id");

            migrationBuilder.CreateIndex(
                name: "IX_issue_project_id",
                table: "issue",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_issue_type_id",
                table: "issue",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_issue_setting_class_id",
                table: "issue_setting",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_issue_setting_project_id",
                table: "issue_setting",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_issue_setting_subject_id",
                table: "issue_setting",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_issue_update_issue_id",
                table: "issue_update",
                column: "issue_id");

            migrationBuilder.CreateIndex(
                name: "IX_milestone_class_id",
                table: "milestone",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_milestone_project_id",
                table: "milestone",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_project_class_id",
                table: "project",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_subject_setting_subject_id",
                table: "subject_setting",
                column: "subject_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "assign_setting");

            migrationBuilder.DropTable(
                name: "class_student");

            migrationBuilder.DropTable(
                name: "issue_update");

            migrationBuilder.DropTable(
                name: "subject_setting");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "assignment");

            migrationBuilder.DropTable(
                name: "issue");

            migrationBuilder.DropTable(
                name: "system_setting");

            migrationBuilder.DropTable(
                name: "issue_setting");

            migrationBuilder.DropTable(
                name: "milestone");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "class");
        }
    }
}
