using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.PhotoGalleryCommands;
using CQRSProject.Entities;

namespace CQRSProject.CQRSPattern.Handlers.PhotoGalleryHandlers
{
    public class CreatePhotoGalleryCommandHandler
    {
        private readonly AppDbContext _context;
        private readonly Services.ICloudStorageService _cloudStorage;

        public CreatePhotoGalleryCommandHandler(AppDbContext context, Services.ICloudStorageService cloudStorage) 
        { 
            _context = context;
            _cloudStorage = cloudStorage;
        }

        public async Task Handle(CreatePhotoGalleryCommand command)
        {
            if (command.ImageFile != null)
            {
                command.ImageUrl = await _cloudStorage.UploadAsync(command.ImageFile.OpenReadStream(), command.ImageFile.FileName, command.ImageFile.ContentType);
            }

            var photo = new PhotoGallery
            {
                Title = command.Title,
                ImageUrl = command.ImageUrl,
                CategoryId = command.CategoryId
            };
            await _context.PhotoGalleries.AddAsync(photo);
            await _context.SaveChangesAsync();
        }
    }
}
