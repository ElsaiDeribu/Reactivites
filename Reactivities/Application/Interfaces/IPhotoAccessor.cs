

using Application.Photos;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadReult> AddPhoto(IFormFile file);
        Task<string> DeletePhoto(string publicId);
    }
}