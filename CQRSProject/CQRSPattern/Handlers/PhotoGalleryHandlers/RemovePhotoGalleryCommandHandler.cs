using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.PhotoGalleryCommands;

namespace CQRSProject.CQRSPattern.Handlers.PhotoGalleryHandlers
{
    public class RemovePhotoGalleryCommandHandler
    {
        private readonly AppDbContext _context;
        public RemovePhotoGalleryCommandHandler(AppDbContext context) { _context = context; }

        public async Task Handle(RemovePhotoGalleryCommand command)
        {
            var photo = await _context.PhotoGalleries.FindAsync(command.Id);
            if (photo != null)
            {
                _context.PhotoGalleries.Remove(photo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
