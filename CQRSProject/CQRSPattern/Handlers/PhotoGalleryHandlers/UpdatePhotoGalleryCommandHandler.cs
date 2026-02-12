using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.PhotoGalleryCommands;

namespace CQRSProject.CQRSPattern.Handlers.PhotoGalleryHandlers
{
    public class UpdatePhotoGalleryCommandHandler
    {
        private readonly AppDbContext _context;
        private readonly Services.ICloudStorageService _cloudStorage;

        public UpdatePhotoGalleryCommandHandler(AppDbContext context, Services.ICloudStorageService cloudStorage)
        {
            _context = context;
            _cloudStorage = cloudStorage;
        }

        public async Task Handle(UpdatePhotoGalleryCommand command)
        {
            var photo = await _context.PhotoGalleries.FindAsync(command.Id);
            if (photo != null)
            {
                if (command.ImageFile != null)
                {
                    command.ImageUrl = await _cloudStorage.UploadAsync(command.ImageFile.OpenReadStream(), command.ImageFile.FileName, command.ImageFile.ContentType);
                }

                photo.Title = command.Title;
                if (!string.IsNullOrEmpty(command.ImageUrl))
                {
                    photo.ImageUrl = command.ImageUrl;
                }
                photo.CategoryId = command.CategoryId;
                await _context.SaveChangesAsync();
            }
        }
    }
}
