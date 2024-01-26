using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LoadXML_RazorPage.Data;
using LoadXML_RazorPage.Models;
using Newtonsoft.Json;

namespace LoadXML_RazorPage.Pages.Persons
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Person Person { get; set; } = default!;
        public List<Person> Persons { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (TempData.TryGetValue("Persons", out var personsJson) && personsJson is string personsJsonString)
            {
                Persons = JsonConvert.DeserializeObject<List<Person>>(personsJsonString);
            }
            Person person = Persons.SingleOrDefault(x => x.Id == id);
            if (id == null || person == null)
            {
                return NotFound();
            }
            else 
            {
                Person = person;
            }
            TempData["Persons"] = JsonConvert.SerializeObject(Persons);
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (TempData.TryGetValue("Persons", out var personsJson) && personsJson is string personsJsonString)
            {
                Persons = JsonConvert.DeserializeObject<List<Person>>(personsJsonString);
            }
            Person person = Persons.SingleOrDefault(x => x.Id == id);
            if (id == null || person == null)
            {
                return NotFound();
            }

            if (person != null)
            {
                Persons.Remove(person);
            }
            TempData["Persons"] = JsonConvert.SerializeObject(Persons);
            return RedirectToPage("./Index");
        }
    }
}
