using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace InReach_Solutions_Junior_Dev_App_Test.Shared{

    public class FileToUpload{
        [Required(ErrorMessage = "Please type a valid email address!")]
        [EmailAddress(ErrorMessage ="Please type a valid email!")]
        public string strEmail {get;set;}

        [Required(ErrorMessage ="Please select a valid file!")]
        [FileValidation(1024*1024, ErrorMessage = "Please select a file smaller than 1MB!")]
        public IBrowserFile ibfUpload {get; set;}

    }
}
