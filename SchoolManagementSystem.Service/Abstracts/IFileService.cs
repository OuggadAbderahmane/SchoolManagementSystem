using Microsoft.AspNetCore.Http;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IFileService
    {
        public Task<string> UploadImage(string filePath, IFormFile fileName);
    }
}
