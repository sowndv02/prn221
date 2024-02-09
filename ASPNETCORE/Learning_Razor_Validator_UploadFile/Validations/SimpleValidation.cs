using System.ComponentModel.DataAnnotations;

namespace Learning_Razor_Validator_UploadFile.Validations
{
    public class SimpleValidation : ValidationAttribute
    {
        public SimpleValidation() => ErrorMessage = "{0} phai la so chan";

        public override bool IsValid(object value)
        {
            if(value == null) return false;

            int i = int.Parse(value.ToString());

            return i % 2 == 0;
        }

    }
}
