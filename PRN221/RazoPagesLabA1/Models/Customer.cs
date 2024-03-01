using Microsoft.AspNetCore.Mvc;
using RazoPagesLabA1.Binding;
using RazoPagesLabA1.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RazoPagesLabA1.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Customer name is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The length of name is from {1} to {0} charaters")]
        [Display(Name = "Customer name")]
        [ModelBinder(BinderType = typeof(CheckNameBinding))]
        public string CustomerName { set; get; }
        [Required(ErrorMessage = "Customer email is required!")]
        [EmailAddress]
        [Display(Name = "Customer email")]
        public string Email {  set; get; }
        [Required(ErrorMessage = "Year of birth is required!")]
        [Display(Name = "Year of birth")]
        [Range(1960, 2000, ErrorMessage = "1960 - 2000")]
        [CustomerValidation]
        public int? YearOfBirth { set; get; }
    }
}
