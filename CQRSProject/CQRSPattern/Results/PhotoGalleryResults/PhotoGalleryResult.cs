namespace CQRSProject.CQRSPattern.Results.PhotoGalleryResults
{
    public class PhotoGalleryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
