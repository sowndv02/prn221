using System;
using System.Collections.Generic;

namespace SEP_Management.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            AssignSettings = new HashSet<AssignSetting>();
        }

        public int AssignId { get; set; }
        public int SubjectId { get; set; }
        public string AssignName { get; set; } = null!;
        public string AssignDescription { get; set; } = null!;
        public byte? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public short? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Part { get; set; } = null!;
        public string Weight { get; set; } = null!;
        public string DueDate { get; set; } = null!;

        public virtual Subject Subject { get; set; } = null!;
        public virtual ICollection<AssignSetting> AssignSettings { get; set; }
    }
}
