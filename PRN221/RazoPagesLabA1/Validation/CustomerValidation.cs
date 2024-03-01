using System.ComponentModel.DataAnnotations;

namespace RazoPagesLabA1.Validation
{
    public class CustomerValidation:ValidationAttribute
    {
        public CustomerValidation() 
        {
            ErrorMessage = $"The year of birth cannot greeter than current year ({DateTime.Now.Year})" ;
        }

        public override bool IsValid(object? value)
        {
            if(value == null)
            {
                return false;
            }
            int number = int.Parse(value.ToString());
            return number < DateTime.Now.Year;
        }

    }
}
