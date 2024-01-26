using LoadXML_RazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Xml.Serialization;
namespace LoadXML_RazorPage.Pages.Persons
{
    public class IndexModel : PageModel
    {
        public List<Person> Persons { get; set; }


        public void OnGet()
        {
            if (TempData.TryGetValue("Persons", out var personsJson) && personsJson is string personsJsonString)
            {
                Persons = JsonConvert.DeserializeObject<List<Person>>(personsJsonString);
            }
            else
            {
                Persons = new List<Person>();
            }
            TempData["Persons"] = JsonConvert.SerializeObject(Persons);
        }
        public void OnPost()
        {
            
        }
        

    }
}
