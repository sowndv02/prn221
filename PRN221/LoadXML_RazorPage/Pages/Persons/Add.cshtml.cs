using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LoadXML_RazorPage.Data;
using LoadXML_RazorPage.Models;
using Newtonsoft.Json;

namespace LoadXML_RazorPage.Pages.Persons
{
    public class AddModel : PageModel
    {

        public List<Person> Persons { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; } = default!;
        

        public IActionResult OnPost()
        {
            if (TempData.TryGetValue("Persons", out var personsJson) && personsJson is string personsJsonString)
            {
                Persons = JsonConvert.DeserializeObject<List<Person>>(personsJsonString);
            }
            if (!ModelState.IsValid || Person == null)
            {
                return Page();
            }
            var person = Persons.FirstOrDefault(x => x.Id == Person.Id);
            if(person != null)
            {
                return Page();
            }
            Persons.Add(Person);
            TempData["Persons"] = JsonConvert.SerializeObject(Persons);
            return RedirectToPage("./Index");
        }
    }
}
