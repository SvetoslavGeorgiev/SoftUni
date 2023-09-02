namespace SchoolMealsOrderingSystem.Core.Contracts
{
    using Amazon.S3.Model;
    using Microsoft.AspNetCore.Http;

    public interface IImageService
    {

        Task<string> UploadImageToAwsS3(string childFullName, IFormFile formFile);
    }
}
