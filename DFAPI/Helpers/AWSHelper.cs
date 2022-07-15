using Amazon.Runtime;
using Amazon.S3;

namespace DFAPI.Helpers
{
    public class AWSHelper
    {
        private readonly BasicAWSCredentials _awsCredentials;
        public AWSHelper(BasicAWSCredentials awsCredentials)
        {
            _awsCredentials = awsCredentials;
        }

        public async Task DeleteFileAsync(string fileName)
        {
            // Set RegionEndpoint to your AWS region.
            AmazonS3Config config = new()
            {
                RegionEndpoint = Amazon.RegionEndpoint.APSouth1
            };

            using var client = new AmazonS3Client(_awsCredentials, config);
            await client.DeleteObjectAsync("samadhanerp", fileName);
        }
    }
}
