using System;
using System.ComponentModel.DataAnnotations;

namespace WebEscuelaMVC.Validations
{
    public class NumeroMayor100Attribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int numeroIngresado = Convert.ToInt32(value);


            if (numeroIngresado < 0)
            {
                return new ValidationResult("El numero debe ser mayor a 100");
            }
            return ValidationResult.Success;
        }

        }
    }

