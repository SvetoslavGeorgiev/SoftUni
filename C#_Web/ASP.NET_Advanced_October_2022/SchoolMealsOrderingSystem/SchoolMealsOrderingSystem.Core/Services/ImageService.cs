namespace SchoolMealsOrderingSystem.Core.Services
{
    using Amazon.Runtime;
    using Amazon.S3;
    using Amazon.S3.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using System.Threading.Tasks;


    public class ImageService : IImageService
    {
        private const string prefix = "child_profile_image/";
        private readonly IConfiguration configuration;

        public ImageService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<string> UploadImageToAwsS3(string childFullName, IFormFile formFile)
        {
            var accessKeyId = configuration.GetConnectionString("AWS:AccessKeyId");
            var secretAccessKey = configuration.GetConnectionString("AWS:SecretAccessKey");
            string bucketName = "schoolmealsorderingsystem-bucket";

            var credentials = new BasicAWSCredentials(accessKeyId, secretAccessKey);
            var s3Client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.EUWest2);

            var extension = Path.GetExtension(formFile.FileName);

            var key = $"{prefix}{childFullName}{extension}";


            var putObjectRequest = new PutObjectRequest
            {
                
                BucketName = bucketName,
                Key = key,
                ContentType = formFile.ContentType,
                InputStream = formFile.OpenReadStream(),

            };

            await s3Client.PutObjectAsync(putObjectRequest);

            return $"https://{bucketName}.s3.eu-west-2.amazonaws.com/{prefix}{childFullName}{extension}";

        }
    }
}
