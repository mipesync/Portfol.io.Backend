using Microsoft.AspNetCore.Http;
using Portfol.io.Application.Interfaces;

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

            Directory.CreateDirectory(AbsolutePath);

            using (var fileStream = new FileStream($"{WebRootPath}{path}", FileMode.Create))
            {
                await File.CopyToAsync(fileStream);
            }

            return path;
        }
    }
}
