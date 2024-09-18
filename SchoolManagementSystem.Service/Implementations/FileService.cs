using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    internal class FileService : IFileService
    {
        #region Fields
        private readonly IHostingEnvironment _hostingEnvironment;
        #endregion

        #region Constructors
        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region Handles Functions
        public async Task<string> UploadImage(string filePath, IFormFile file)
        {
            var path = _hostingEnvironment.WebRootPath + '/' + filePath + '/';
            var Extention = Path.GetExtension(file.FileName);
            if (Extention == null)
                return null!;
            var fileName = Guid.NewGuid() + Extention;
            if (file.Length != 0)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fileStream = File.Create(path + fileName))
                {
                    await file.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                    return filePath + '/' + fileName;
                }
            }
            return null!;
        }
        #endregion
    }
}
