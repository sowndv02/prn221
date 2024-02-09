using Learning_Razor_Validator_UploadFile.Models;
using Learning_Razor_Validator_UploadFile.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Learning_Razor_Validator_UploadFile.Pages
{

    public class ContactModel : PageModel
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public ContactModel(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [BindProperty]
        public CustomerInfo customerInfo { get; set; }


        [BindProperty]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Chon file upload")]
        [CheckFileExtensions(Extensions = "jpg,png,gif")]
        [DisplayName("File Upload")]
        public IFormFile FileUpload { get;set; }


        public IFormFile[] FileUpLoads { get; set; }
        public void OnGet()
        {
        }

        public string Message { get; set; }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                if(FileUpload != null)
                {
                    var file = Path.Combine(_environment.ContentRootPath, "uploads", FileUpload.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        FileUpload.CopyTo(fileStream);
                    }
                }

                if (FileUpLoads != null)
                {
                    foreach (var FileUpload in FileUpLoads)
                    {
                        var file = Path.Combine(_environment.ContentRootPath, "uploads", FileUpload.FileName);
                        using (var fileStream = new FileStream(file, FileMode.Create))
                        {
                            FileUpload.CopyToAsync(fileStream);
                        }
                    }
                }

            }
            else
            {

            }
        }
    }
}
