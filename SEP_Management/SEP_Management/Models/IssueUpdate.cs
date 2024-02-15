using System;
using System.Collections.Generic;

namespace SEP_Management.Models
{
    public partial class IssueUpdate
    {
        public int UpdatedId { get; set; }
        public int? IssueId { get; set; }
        public int? MilestoneId { get; set; }
        public string? Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Issue? Issue { get; set; }
    }
}
