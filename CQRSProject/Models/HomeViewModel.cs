namespace CQRSProject.Models
{
    public class HomeViewModel
    {
        public List<SliderViewModel> Sliders { get; set; } = new List<SliderViewModel>();
        public List<ThreeStepServiceViewModel> ThreeStepServices { get; set; } = new List<ThreeStepServiceViewModel>();
        public OurHistoryViewModel? OurHistory { get; set; }
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
        public List<ServiceViewModel> Services { get; set; } = new List<ServiceViewModel>();
        public List<PhotoGalleryViewModel> PhotoGalleries { get; set; } = new List<PhotoGalleryViewModel>();
        public List<PromotionViewModel> Promotions { get; set; } = new List<PromotionViewModel>();
        public List<TestimonialViewModel> Testimonials { get; set; } = new List<TestimonialViewModel>();
    }

    public class SliderViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string ButtonText { get; set; } = string.Empty;
        public string ButtonUrl { get; set; } = string.Empty;
        public string BackgroundColor { get; set; } = "#e8382e";
    }

    public class ThreeStepServiceViewModel
    {
        public int StepNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class OurHistoryViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string SignatureImageUrl { get; set; } = string.Empty;
        public string OverviewTitle { get; set; } = string.Empty;
        public string OverviewDescription { get; set; } = string.Empty;
        public List<string> OverviewItems { get; set; } = new List<string>();
    }

    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }

    public class ServiceViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }

    public class PhotoGalleryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }

    public class PromotionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; } = 100;
        public decimal DiscountPercentage { get; set; }
    }

    public class TestimonialViewModel
    {
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerTitle { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
