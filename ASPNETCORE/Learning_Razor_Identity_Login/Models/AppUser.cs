using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_Razor_Identity_Login.Models
{
    public class AppUser: IdentityUser
    {
        [Column (TypeName ="nvarchar")]
        [StringLength(400)]
        public string HomeAddress { get ; set; }    

    }
}
