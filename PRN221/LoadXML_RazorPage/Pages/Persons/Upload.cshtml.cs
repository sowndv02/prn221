using LoadXML_RazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace LoadXML_RazorPage.Pages.Persons
{
    public class UploadModel : PageModel
    {
        public List<Person> Persons
        {
            get
            {
                if (TempData.TryGetValue("Persons", out var persons))
                {
                    return (List<Person>)persons;
                }
                return new List<Person>();
            }
            set => TempData["Persons"] = value;
        }


        public void OnGet()
        {
        }
        public IActionResult OnPost(IFormCollection _form)
        {
            if (_form.Files.Count > 0)
            {
                foreach (IFormFile formFile in _form.Files)
                {
                    if (formFile.Length > 0)
                    {
                        var filePath = Path.Combine("wwwroot", "upload", formFile.FileName);
                        if (!Directory.Exists("wwwroot/upload/")) Directory.CreateDirectory("wwwroot/upload/");
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }

                        var serializer = new XmlSerializer(typeof(List<Person>));
                        using (Stream xmlStream = System.IO.File.OpenRead(filePath))
                        {
                            Persons = (List<Person>)serializer.Deserialize(xmlStream); 
                        }
                    }
                }
                TempData["Persons"] = JsonConvert.SerializeObject(Persons);
                return RedirectToPage("Index");
            }

            ModelState.AddModelError("File", "Please select a file.");
            return Page();
        }
    }
}
