using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Amazon.Runtime;

namespace BYU_FEG.Models
{
    public class S3File
    {
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;
        private static IAmazonS3 s3Client;

        public static async Task UploadImage(IFormFile file)
        {
            var credentials = new BasicAWSCredentials("AKIAWTI6ADB4WUZ3DEH4", "BA7bWFFer4wCtiXzNp5u8fMqhKEnKZoubxGpaRif");
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };
            using var client = new AmazonS3Client(credentials, config);
            await using var newMemoryStream = new MemoryStream();
            file.CopyTo(newMemoryStream);
            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = newMemoryStream,
                Key = file.FileName,
                BucketName = "elasticbeanstalk-us-east-1-453718841465",
                CannedACL = S3CannedACL.PublicRead
            };
            var fileTransferUtility = new TransferUtility(client);
            await fileTransferUtility.UploadAsync(uploadRequest);
        }

        /*public static async Task UploadFileAsync(Stream FileStream, string bucketName, string keyName)
        {
            s3Client = new AmazonS3Client(bucketRegion);
            var fileTransferUtility = new TransferUtility(s3Client);
            await fileTransferUtility.UploadAsync(FileStream, bucketName, keyName);
        }*/
    }
}
