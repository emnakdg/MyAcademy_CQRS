using Microsoft.AspNetCore.Http;

namespace CQRSProject.CQRSPattern.Commands.PhotoGalleryCommands
{
    public class UpdatePhotoGalleryCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
        public int CategoryId { get; set; }
    }
}
