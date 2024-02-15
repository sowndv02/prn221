using System;
using System.Collections.Generic;

namespace SEP_Management.Models
{
    public partial class AssignSetting
    {
        public int AssignId { get; set; }
        public int SettingId { get; set; }
        public byte SettingGroup { get; set; }
        public string SettingName { get; set; } = null!;
        public string SettingValue { get; set; } = null!;
        public string DisplayOrder { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual Assignment Assign { get; set; } = null!;
    }
}
