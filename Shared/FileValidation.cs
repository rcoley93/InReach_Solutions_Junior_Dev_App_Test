using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InReach_Solutions_Junior_Dev_App_Test.Shared
{
    public class FileValidation: ValidationAttribute
    {
        private long lMaxFileSize = 0;
        public FileValidation(long MaxFileSize)
        {
            this.lMaxFileSize = MaxFileSize;
        }
        protected override ValidationResult IsValid(object value, ValidationContext VC)
        {
            IBrowserFile ibfValue = (IBrowserFile)value;
            Console.WriteLine($"File Size: {ibfValue.Size}");
            if (ibfValue.Size > this.lMaxFileSize)
            {
                return new ValidationResult("Please select a smaller file!",new[] { VC.MemberName});
            }

            return ValidationResult.Success;
        }
    }
}
