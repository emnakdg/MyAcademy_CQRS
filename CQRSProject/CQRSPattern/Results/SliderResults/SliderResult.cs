namespace CQRSProject.CQRSPattern.Results.SliderResults
{
    public class SliderResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
    }
}
