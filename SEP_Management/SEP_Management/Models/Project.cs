using System;
using System.Collections.Generic;

namespace SEP_Management.Models
{
    public partial class Project
    {
        public Project()
        {
            IssueSettings = new HashSet<IssueSetting>();
            Issues = new HashSet<Issue>();
            Milestones = new HashSet<Milestone>();
        }

        public int ProjectId { get; set; }
        public string? ProjectCode { get; set; }
        public string? ProjectEnName { get; set; }
        public string? ProjectVieName { get; set; }
        public string? ProjectDescription { get; set; }
        public byte? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ClassId { get; set; }
        public string? GroupName { get; set; }
        public string? MentorId { get; set; }
        public string? CoMentorId { get; set; }
        public string? AccessToken { get; set; }
        public string? Url { get; set; }

        public virtual Class? Class { get; set; }
        public virtual ICollection<IssueSetting> IssueSettings { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<Milestone> Milestones { get; set; }
    }
}
