namespace CQRSProject.Services
{
    public interface ICloudStorageService
    {
        Task<string> UploadAsync(Stream fileStream, string fileName, string contentType);
        Task DeleteAsync(string fileUrl);
        Task<string> GetUrlAsync(string blobName);
    }
}
