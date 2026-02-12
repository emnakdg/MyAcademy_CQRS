using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace CQRSProject.Services
{
    public class CloudinaryStorageService : ICloudStorageService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryStorageService(IConfiguration configuration)
        {
            var cloudName = configuration["Cloudinary:CloudName"];
            var apiKey = configuration["Cloudinary:ApiKey"];
            var apiSecret = configuration["Cloudinary:ApiSecret"];

            var account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);
            _cloudinary.Api.Secure = true;
        }

        public async Task<string> UploadAsync(Stream fileStream, string fileName, string contentType)
        {
            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileNameWithoutExtension(fileName)}";
            
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, fileStream),
                PublicId = uniqueFileName,
                Folder = "bakery"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            
            if (uploadResult.Error != null)
            {
                throw new Exception($"Cloudinary upload failed: {uploadResult.Error.Message}");
            }

            return uploadResult.SecureUrl.ToString();
        }

        public async Task DeleteAsync(string fileUrl)
        {
            try
            {
                var uri = new Uri(fileUrl);
                var pathSegments = uri.AbsolutePath.Split('/');
                
                var folderAndFile = string.Join("/", pathSegments.Skip(pathSegments.Length - 2));
                var publicId = Path.GetFileNameWithoutExtension(folderAndFile);
                
                if (folderAndFile.Contains("bakery/"))
                {
                    publicId = "bakery/" + Path.GetFileNameWithoutExtension(pathSegments.Last());
                }

                var deleteParams = new DeletionParams(publicId);
                await _cloudinary.DestroyAsync(deleteParams);
            }
            catch
            {

            }
        }

        public Task<string> GetUrlAsync(string blobName)
        {
            var url = _cloudinary.Api.UrlImgUp
                .Transform(new Transformation().Quality("auto").FetchFormat("auto"))
                .BuildUrl($"bakery/{blobName}");
            
            return Task.FromResult(url);
        }
    }
}
