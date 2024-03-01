using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using System.ComponentModel.DataAnnotations;

namespace RazoPagesLabA1.Pages
{
    public class UploadFilesModel : PageModel
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public UploadFilesModel(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [Required(ErrorMessage = "Please choose at least one file.")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name = "Choose file(s) to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }


        public async Task OnPostAsync()
        {
            if (FileUploads != null)
            {
                foreach (var fileUpload in FileUploads)
                {
                    var file = Path.Combine(_environment.ContentRootPath, "Images", fileUpload.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await fileUpload.CopyToAsync(fileStream);
                    }
                }
            }
        }
    }
}
