using System.ComponentModel.DataAnnotations;

namespace Aplicacion.Validations
{
    public class NotZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return true;

            if (value is double d)
            {
                return d != 0;
            }

            return false;
        }
    }

}
