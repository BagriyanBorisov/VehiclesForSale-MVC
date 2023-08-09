using System;
using System.ComponentModel.DataAnnotations;

namespace VehiclesForSale.Common
{
    public class PriceToLessThanOrEqualAttribute : ValidationAttribute
    {
        private readonly string _otherProperty;

        public PriceToLessThanOrEqualAttribute(string otherProperty)
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

            if (otherValue.HasValue && value is int currentValue && currentValue < otherValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}

