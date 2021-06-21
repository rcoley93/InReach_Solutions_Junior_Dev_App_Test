using Amazon;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.IO;
using System.Threading.Tasks;

namespace InReach_Solutions_Junior_Dev_App_Test.Services
{
    public class AWSFileUploadService : IAWSService
    {
        private readonly AWSSettings awssConfig;
        private readonly AmazonS3Client s3Client;

        public AWSFileUploadService(AWSSettings Config)
        {
            this.awssConfig = Config;

            /*var cpoAWS = new CredentialProfileOptions
            {
                AccessKey = Config.strAccessKey,
                SecretKey = Config.strSecretKey
            };

            var cpAWS = new CredentialProfile("default_profile", cpoAWS);
            cpAWS.Region = RegionEndpoint.USWest2;

            var netSDKFile = new NetSDKCredentialsFile();
            netSDKFile.RegisterProfile(cpAWS);*/

            this.s3Client = new AmazonS3Client(Config.strAccessKey,Config.strSecretKey,RegionEndpoint.USWest2);

            AWSConfigsS3.UseSignatureVersion4 = true;
        }

        public UploadResult GeneratePresignedUrl(string Key)
        {
            GetPreSignedUrlRequest urlRequest = new GetPreSignedUrlRequest
            {
                BucketName = this.awssConfig.strBucketName,
                Key = Key,
                Expires = DateTime.Now.AddHours(1)
            };

            try
            {
                string strPath = this.s3Client.GetPreSignedURL(urlRequest);
                return new UploadResult
                {
                    strMessage = strPath,
                    blnStatus = true
                };
            }
            catch (Exception ex)
            {
                return new UploadResult
                {
                    blnStatus = false,
                    strMessage = $"Error Occurred: {ex.Message}"
                };
            }
        }

        public async Task<UploadResult> UploadFile(Stream FileStream, string Key)
        {
            try
            {
                var tuFile = new TransferUtility(this.s3Client);
                await tuFile.UploadAsync(FileStream, this.awssConfig.strBucketName, Key);
                return new UploadResult
                {
                    blnStatus = true,
                    strMessage = Key
                };
            }
            catch(Exception ex)
            {
                return new UploadResult
                {
                    blnStatus = false,
                    strMessage = $"Error Occurred: {ex.Message}"
                };
            }
        }
    }
}
