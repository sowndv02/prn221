using System;
using System.Collections.Generic;

namespace SEP_Management.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Assignments = new HashSet<Assignment>();
            IssueSettings = new HashSet<IssueSetting>();
            SubjectSettings = new HashSet<SubjectSetting>();
        }

        public int SubjectId { get; set; }
        public string SubjectCode { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
        public string ManagerId { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public string Description { get; set; } = null!;
        public string TimeAllocation { get; set; } = null!;
        public byte PassGrade { get; set; }

        public virtual User Manager { get; set; } = null!;
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<IssueSetting> IssueSettings { get; set; }
        public virtual ICollection<SubjectSetting> SubjectSettings { get; set; }
    }
}
