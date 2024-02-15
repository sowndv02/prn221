using System;
using System.Collections.Generic;

namespace SEP_Management.Models
{
    public partial class SystemSetting
    {
        public SystemSetting()
        {
            Users = new HashSet<User>();
        }

        public int SettingId { get; set; }
        public int SettingGroup { get; set; }
        public string SettingName { get; set; } = null!;
        public int DisplayOrder { get; set; }
        public string Description { get; set; } = null!;
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
