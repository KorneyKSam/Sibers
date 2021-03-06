﻿using Sibers.DbStuff.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sibers.Models.CustomAttributes
{
    public class UniqueExecutingCompanyNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if( value != null && !(value is string))
                throw new Exception("This Attribute must be applied for string");
            if (value == null)
                return new ValidationResult("Value can't be null");

            var company = (string)value;
            var executingCompanyRepository= validationContext.GetService(typeof(Executing_Company_Repository)) as Executing_Company_Repository;
            var existingCompany = executingCompanyRepository.FindExistingExecutingCompany(company);
            
            if (existingCompany != null)
                return new ValidationResult($"{company} is not unique name.");

            return ValidationResult.Success;
        }
    }
}
