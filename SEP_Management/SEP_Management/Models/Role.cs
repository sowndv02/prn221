using Microsoft.AspNetCore.Identity;

namespace SEP_Management.Models
{
    public class Role : IdentityRole
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public int Group { get; set; }
        public int? DisplayOrder { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
