﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace UtilsValidation.UserValidation
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    sealed public class IdNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (ClientValidation.ValidateCpf(value.ToString()) || ClientValidation.ValidateCnpj(value.ToString()));
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }
    }
}
