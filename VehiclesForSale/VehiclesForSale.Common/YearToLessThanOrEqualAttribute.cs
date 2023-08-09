using System;
using System.ComponentModel.DataAnnotations;

namespace VehiclesForSale.Common
{
    public class YearToLessThanOrEqualAttribute : ValidationAttribute
    {
        private readonly string _otherProperty;

        public YearToLessThanOrEqualAttribute(string otherProperty)
        {
            _otherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_otherProperty);

            if (property == null)
            {
                return new ValidationResult($"Unknown property: {_otherProperty}");
            }

            var otherValue = (int?)property.GetValue(validationContext.ObjectInstance);

            if (otherValue.HasValue && value is int currentYear && currentYear < otherValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}

