using System;
using System.Collections.Generic;

namespace SEP_Management.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassStudents = new HashSet<ClassStudent>();
            IssueSettings = new HashSet<IssueSetting>();
            Milestones = new HashSet<Milestone>();
            Projects = new HashSet<Project>();
        }

        public int ClassId { get; set; }
        public string? ClassCode { get; set; }
        public string? ClassDetails { get; set; }
        public int? SemesterId { get; set; }
        public int? SubjectId { get; set; }
        public string? ManagerId { get; set; }
        public byte? Status { get; set; }
        public short? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public short? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? GitlabId { get; set; }
        public string? AccessToken { get; set; }

        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
        public virtual ICollection<IssueSetting> IssueSettings { get; set; }
        public virtual ICollection<Milestone> Milestones { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
