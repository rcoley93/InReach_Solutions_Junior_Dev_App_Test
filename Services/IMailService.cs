using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InReach_Solutions_Junior_Dev_App_Test.Services
{
    interface IMailService
    {
        Task SendEmail(string ToEmail, string Subject, string HTMLBody);
    }
}
