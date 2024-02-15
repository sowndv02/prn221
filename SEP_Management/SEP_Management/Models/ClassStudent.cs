using System;
using System.Collections.Generic;

namespace SEP_Management.Models
{
    public partial class ClassStudent
    {
        public int ClassStId { get; set; }
        public int ClassId { get; set; }
        public string StudentId { get; set; } = null!;
        public byte IsActive { get; set; }
        public string Note { get; set; } = null!;
        public short CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public short UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ProjectId { get; set; }
        public byte IsLeader { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual User Student { get; set; } = null!;
    }
}
