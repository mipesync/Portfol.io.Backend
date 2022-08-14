using Microsoft.AspNetCore.Http;

namespace Portfol.io.Application.Interfaces
{
    public interface IImageUploader
    {
        IFormFile File { get; set; }
        string AbsolutePath { get; set; }

        Task<string> Upload();
    }
}
