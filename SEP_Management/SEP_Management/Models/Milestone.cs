using System;
using System.Collections.Generic;

namespace SEP_Management.Models
{
    public partial class Milestone
    {
        public Milestone()
        {
            Issues = new HashSet<Issue>();
        }
        public int MilestoneId { get; set; }
        public string? MinestoneName { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public byte? IsActive { get; set; }
        public int? ClassId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public string? GitlabId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Project? Project { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
