using System;
using System.Collections.Generic;

namespace SEP_Management.Models
{
    public partial class SubjectSetting
    {
        public int SettingId { get; set; }
        public string? SettingName { get; set; }
        public int? SettingType { get; set; }
        public int? SettingValue { get; set; }
        public int? SubjectId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Subject? Subject { get; set; }
    }
}
