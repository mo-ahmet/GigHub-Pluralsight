using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Gighub.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime datetime;
            var IsVaild = DateTime.TryParseExact(
                Convert.ToString(value),
                "d MMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out datetime);

            return (IsVaild && datetime > DateTime.Now);
        }
    }
}