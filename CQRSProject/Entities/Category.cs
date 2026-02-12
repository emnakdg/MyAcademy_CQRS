namespace CQRSProject.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Product> Products { get; set; }
        public IList<PhotoGallery> PhotoGalleries { get; set; }
    }
}
