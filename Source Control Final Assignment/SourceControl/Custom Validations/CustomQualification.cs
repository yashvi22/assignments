using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace SourceControl.Custom_Validations
{
    public class CustomQualification : ValidationAttribute
    {
        public override bool IsValid(Object value)
        {
            string qual = Convert.ToString(value);

            return qual == "BE";
        }
    }
}