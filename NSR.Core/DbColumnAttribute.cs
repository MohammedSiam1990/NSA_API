using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace NSR.Core
{
    [Serializable]
    [JsonObject]
    public class DbColumnAttribute : Attribute
    {
        public string Name { get; private set; }

        public DbColumnAttribute(string name)
        {
            this.Name = name;
        }
    }

    [Serializable]
    [JsonObject]
    public class DateFormatValidatorAttribute : RegularExpressionAttribute
    {
        public DateFormatValidatorAttribute()
            : base(@"^((0[1-9])|([1-2][0-9])|3[0-1])\/((0[1-9])|(1[0-2]))\/[0-9]{4}$")
        {
            ErrorMessage = "*";
        }

        public override bool IsValid(object value)
        {
            return true;
        }
    }

    [Serializable]
    [JsonObject]
    public class CheckPolicyEffectiveDateAttribute : ValidationAttribute
    {
        public CheckPolicyEffectiveDateAttribute() { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] strSplit = value.ToString().Split(new char[] { '-', '/' });
            DateTime podate = new DateTime(Convert.ToInt32(strSplit[2]), Convert.ToInt32(strSplit[1]), Convert.ToInt32(strSplit[0])).Date;
            DateTime currentDate = DateTime.Now.AddDays(1).Date;
            DateTime endDate = currentDate.AddDays(15).Date;

            if (podate <= endDate && podate >= currentDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date is not later");
            }
        }
    }
}
