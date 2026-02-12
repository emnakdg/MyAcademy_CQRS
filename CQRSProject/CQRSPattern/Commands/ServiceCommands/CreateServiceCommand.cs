namespace CQRSProject.CQRSPattern.Commands.ServiceCommands
{
    public class CreateServiceCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }
    }
}
