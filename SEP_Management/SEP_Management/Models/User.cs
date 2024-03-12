using Microsoft.AspNetCore.Identity;

namespace SEP_Management.Models
{
    public partial class User : IdentityUser
    {
        public User()
        {
            ClassStudents = new HashSet<ClassStudent>();
            Subjects = new HashSet<Subject>();
        }


        public string? AvatarUrl { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? RoleId { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte? IsActive { get; set; }
        public string? AccessToken { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual Role? Role { get; set; }
    }
}
