namespace CQRSProject.CQRSPattern.Commands.SliderCommands
{
    public class CreateSliderCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
    }
}
