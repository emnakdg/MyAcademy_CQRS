namespace CQRSProject.CQRSPattern.Commands.TestimonialCommands
{
    public class CreateTestimonialCommand
    {
        public string CustomerName { get; set; }
        public string CustomerTitle { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public int Rating { get; set; }
    }
}
