using Microsoft.AspNetCore.Http;
using Portfol.io.Application.Interfaces;
using FileIO = System.IO.File;

namespace Portfol.io.Persistence.Services
{
    public class ImageUploader : IImageUploader
    {
        public IFormFile File { get; set; } = null!;
        public string AbsolutePath { get; set; } = null!;
        public string WebRootPath { get; set; } = null!;

        public async Task<string> Upload()
        {
            var fileExtension = Path.GetExtension(File.FileName);
            var fileNameHash = Guid.NewGuid().ToString();
            string path = $"{AbsolutePath}/{fileNameHash}{fileExtension}";
            string directoryPath = String.Concat(WebRootPath, AbsolutePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (var fileStream = FileIO.Create(String.Concat(WebRootPath, path)))
            {
                await File.CopyToAsync(fileStream);
            }

            return path;
        }
    }
}
