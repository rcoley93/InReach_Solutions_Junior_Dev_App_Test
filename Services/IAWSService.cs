using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InReach_Solutions_Junior_Dev_App_Test.Services
{
    interface IAWSService
    {
        Task<UploadResult> UploadFile(Stream File, string strFilename);

        UploadResult GeneratePresignedUrl(string Key);
    }
}
