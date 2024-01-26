using LoadXML_RazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace LoadXML_RazorPage.Pages.Persons
{
    public class SaveFileModel : PageModel
    {
        public List<Person> Persons { get; set; }
        public IActionResult OnGet()
        {
            if (TempData.TryGetValue("Persons", out var personsJson) && personsJson is string personsJsonString)
            {
                Persons = JsonConvert.DeserializeObject<List<Person>>(personsJsonString);
            }
            if (Persons != null && Persons.Count > 0 )
            {
                var filePath = Path.Combine("wwwroot", "save", "savedPersons.xml");
                var serializer = new XmlSerializer(typeof(List<Person>));
                using Stream stream = System.IO.File.Create(filePath);
                serializer.Serialize(stream, Persons);
            }
            return RedirectToPage("/Index");
        }
    }
}
