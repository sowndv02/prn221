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
    public class DetailsModel : PageModel
    {
        public List<Person> Persons { get; set; }

        public Person Person { get; set; } = default!; 

        public IActionResult OnGet(int? id)
        {
            if (TempData.TryGetValue("Persons", out var personsJson) && personsJson is string personsJsonString)
            {
                Persons = JsonConvert.DeserializeObject<List<Person>>(personsJsonString);
            }
            var person = Persons.FirstOrDefault(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            TempData["Persons"] = JsonConvert.SerializeObject(Persons);
            Person = person;
            return Page();
        }
    }
}
