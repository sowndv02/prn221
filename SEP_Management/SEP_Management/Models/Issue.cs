using System;
using System.Collections.Generic;

namespace SEP_Management.Models
{
    public partial class Issue
    {
        public Issue()
        {
            IssueUpdates = new HashSet<IssueUpdate>();
        }

        public int IssueId { get; set; }
        public int? ProjectId { get; set; }
        public int? MilestoneId { get; set; }
        public int? TypeId { get; set; }
        public int? StatusId { get; set; }
        public int? ProcessId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Milestone? Milestone { get; set; }
        public virtual Project? Project { get; set; }
        public virtual IssueSetting? Type { get; set; }
        public virtual ICollection<IssueUpdate> IssueUpdates { get; set; }
    }
}
