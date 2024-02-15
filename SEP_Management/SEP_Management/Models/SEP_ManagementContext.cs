using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SEP_Management.Models
{
    public partial class SEP_ManagementContext : IdentityDbContext<User>
    {
        public SEP_ManagementContext()
        {
        }

        public SEP_ManagementContext(DbContextOptions<SEP_ManagementContext> options) : base(options)
        {
        }

        public virtual DbSet<AssignSetting> AssignSettings { get; set; } = null!;
        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<ClassStudent> ClassStudents { get; set; } = null!;
        public virtual DbSet<Issue> Issues { get; set; } = null!;
        public virtual DbSet<IssueSetting> IssueSettings { get; set; } = null!;
        public virtual DbSet<IssueUpdate> IssueUpdates { get; set; } = null!;
        public virtual DbSet<Milestone> Milestones { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<SubjectSetting> SubjectSettings { get; set; } = null!;
        public virtual DbSet<SystemSetting> SystemSettings { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=COOKIE\\SQLEXPRESS;database=SEP_Management;uid=sa;password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.ToTable("assign_setting");

                entity.Property(e => e.SettingId).HasColumnName("setting_id");

                entity.Property(e => e.AssignId).HasColumnName("assign_id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.DisplayOrder)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("display_order");

                entity.Property(e => e.SettingGroup).HasColumnName("setting_group");

                entity.Property(e => e.SettingName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("setting_name");

                entity.Property(e => e.SettingValue)
                    .HasMaxLength(10)
                    .HasColumnName("setting_value")
                    .IsFixedLength();

                entity.HasOne(d => d.Assign)
                    .WithMany(p => p.AssignSettings)
                    .HasForeignKey(d => d.AssignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assign_setting_assignment");
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => e.AssignId);

                entity.ToTable("assignment");

                entity.Property(e => e.AssignId).HasColumnName("assign_id");

                entity.Property(e => e.AssignDescription)
                    .HasColumnType("text")
                    .HasColumnName("assign_description");

                entity.Property(e => e.AssignName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("assign_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DueDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("due_date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Part)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("part");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.Weight)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("weight");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assignment_subject");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("class");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("access_token");

                entity.Property(e => e.ClassCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("class_code");

                entity.Property(e => e.ClassDetails)
                    .HasColumnType("text")
                    .HasColumnName("class_details");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.GitlabId)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("gitlab_id");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.SemesterId).HasColumnName("semester_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            });

            modelBuilder.Entity<ClassStudent>(entity =>
            {
                entity.HasKey(e => e.ClassStId);

                entity.ToTable("class_student");

                entity.Property(e => e.ClassStId).HasColumnName("class_st_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsLeader).HasColumnName("is_leader");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasColumnName("note");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassStudents)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_class_student_class");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ClassStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_class_student_user");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.ToTable("issue");

                entity.Property(e => e.IssueId).HasColumnName("issue_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.MilestoneId).HasColumnName("milestone_id");

                entity.Property(e => e.ProcessId).HasColumnName("process_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Milestone)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.MilestoneId)
                    .HasConstraintName("FK_issue_milestone");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_issue_project");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_issue_issue_setting");
            });

            modelBuilder.Entity<IssueSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.ToTable("issue_setting");

                entity.Property(e => e.SettingId).HasColumnName("setting_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.IssueSettings)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_issue_setting_class");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.IssueSettings)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_issue_setting_project");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.IssueSettings)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_issue_setting_subject");
            });

            modelBuilder.Entity<IssueUpdate>(entity =>
            {
                entity.HasKey(e => e.UpdatedId);

                entity.ToTable("issue_update");

                entity.Property(e => e.UpdatedId).HasColumnName("updated_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.IssueId).HasColumnName("issue_id");

                entity.Property(e => e.MilestoneId).HasColumnName("milestone_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.IssueUpdates)
                    .HasForeignKey(d => d.IssueId)
                    .HasConstraintName("FK_issue_update_issue");
            });

            modelBuilder.Entity<Milestone>(entity =>
            {
                entity.ToTable("milestone");

                entity.Property(e => e.MilestoneId).HasColumnName("milestone_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("due_date");

                entity.Property(e => e.GitlabId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gitlab_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.MinestoneName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("minestone_name");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Milestones)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_milestone_class");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Milestones)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_milestone_project");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.Property(e => e.ProjectId).HasColumnName("project_Id");

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("access_token");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.CoMentorId).HasColumnName("co_mentor_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("group_name");

                entity.Property(e => e.MentorId).HasColumnName("mentor_id");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("project_code");

                entity.Property(e => e.ProjectDescription)
                    .HasColumnType("text")
                    .HasColumnName("project_description");

                entity.Property(e => e.ProjectEnName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("project_en_name");

                entity.Property(e => e.ProjectVieName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("project_vie_name");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("url");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_project_class");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subject");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.PassGrade).HasColumnName("pass_grade");

                entity.Property(e => e.SubjectCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subject_code");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("subject_name");

                entity.Property(e => e.TimeAllocation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("time_allocation");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subject_user");
            });

            modelBuilder.Entity<SubjectSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.ToTable("subject_setting");

                entity.Property(e => e.SettingId).HasColumnName("setting_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.SettingName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("setting_name");

                entity.Property(e => e.SettingType).HasColumnName("setting_type");

                entity.Property(e => e.SettingValue).HasColumnName("setting_value");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectSettings)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_subject_setting_subject");
            });

            modelBuilder.Entity<SystemSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.ToTable("system_setting");

                entity.Property(e => e.SettingId).HasColumnName("setting_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.DisplayOrder).HasColumnName("display_order");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.SettingGroup).HasColumnName("setting_group");

                entity.Property(e => e.SettingName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("setting_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            });

            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }

    }
}
