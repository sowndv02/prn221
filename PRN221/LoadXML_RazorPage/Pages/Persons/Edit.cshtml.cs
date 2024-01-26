using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoadXML_RazorPage.Data;
using LoadXML_RazorPage.Models;
using Newtonsoft.Json;

namespace LoadXML_RazorPage.Pages.Persons
{
    public class EditModel : PageModel
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
            var person = Persons.FirstOrDefault(x => x.Id == id);
            if(person == null) 
            { 
                return NotFound();
            }
            TempData["Persons"] = JsonConvert.SerializeObject(Persons);
            Person = person;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (TempData.TryGetValue("Persons", out var personsJson) && personsJson is string personsJsonString)
            {
                Persons = JsonConvert.DeserializeObject<List<Person>>(personsJsonString);
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var person = Persons.FirstOrDefault(x => x.Id == Person.Id);
            person.Name = Person.Name;  
            person.Gender = Person.Gender;
            person.Gpa = Person.Gpa;
            person.Dob = Person.Dob;
            TempData["Persons"] = JsonConvert.SerializeObject(Persons);

            return RedirectToPage("./Index");
        }
        
    }
}
