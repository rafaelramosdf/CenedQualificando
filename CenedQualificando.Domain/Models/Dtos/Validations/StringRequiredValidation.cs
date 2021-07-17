using CenedQualificando.Domain.Resources;
using System.ComponentModel.DataAnnotations;

namespace CenedQualificando.Domain.Models.Dtos.Validations
{
    public class StringRequiredValidation : ValidationAttribute
    {
        protected string FieldName { get; set; }

        public StringRequiredValidation(string fieldName)
        {
            FieldName = fieldName;
        }

        public string GetErrorMessage() => string.Format(ValidationMessageResource.CampoObrigatorio, FieldName);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var fieldValue = (string)value;

            if (string.IsNullOrEmpty(fieldValue))
                return new ValidationResult(GetErrorMessage());

            return ValidationResult.Success;
        }
    }
}
