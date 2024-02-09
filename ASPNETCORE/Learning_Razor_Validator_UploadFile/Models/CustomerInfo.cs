using Learning_Razor_Validator_UploadFile.Binders;
using Learning_Razor_Validator_UploadFile.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Learning_Razor_Validator_UploadFile.Models
{
    public class CustomerInfo
    {
        [Display(Name = "Tên khách hàng")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [StringLength(20, MinimumLength =3, ErrorMessage ="Tên sai cmnr. {0} phải dài từ {2} đến {1} ký tụ")]
        [ModelBinder(BinderType = typeof(UserNameBinding))]  // Khi binding dữ liệu sẽ chuyển in hoa, không chứa XXX
        public string CustomerName {  get; set; }
        [Display(Name = "Email khách hàng")]
        [EmailAddress(ErrorMessage = "Phải nhập {0}")]
        public string Email { get; set; }
        [Display(Name = "Năm sinh khách hàng")]
        [Range(1970, 2000, ErrorMessage ="{0} sai phải trong khoảng {1} đến {2}")]
        [SimpleValidation]
        public int? YearOfBirth { get; set; } 
    }
}
