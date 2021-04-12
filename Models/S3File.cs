using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYU_FEG.Models
{
    public class S3File
    {
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.EUWest2;
        private static IAmazonS3 s3Client;

        public static async Task UploadFileAsync(Stream FileStream, string bucketName, string keyName)
        {
            s3Client = new AmazonS3Client(bucketRegion);
            var fileTransferUtility = new TransferUtility(s3Client);
            await fileTransferUtility.UploadAsync(FileStream, bucketName, keyName);
        }
    }
}
