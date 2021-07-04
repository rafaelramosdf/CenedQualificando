﻿using CenedQualificando.Domain.Extensions;
using System.ComponentModel.DataAnnotations;

namespace CenedQualificando.Domain.Models.Dtos.Validations
{
    public class CpfValidation : ValidationAttribute
    {
        public string GetErrorMessage() => $"CPF inválido";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cpf = (string)value;

            if (!cpf.CPFValido())
                return new ValidationResult(GetErrorMessage());

            return ValidationResult.Success;
        }
    }
}
