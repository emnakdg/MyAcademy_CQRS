using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.SliderCommands;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.SliderHandlers
{
    public class UpdateSliderCommandHandler
    {
        private readonly AppDbContext _context;

        public UpdateSliderCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateSliderCommand command)
        {
            var slider = await _context.Sliders.FindAsync(command.Id);
            if (slider != null)
            {
                slider.Title = command.Title;
                slider.Description = command.Description;
                slider.ImageUrl = command.ImageUrl;
                slider.ButtonText = command.ButtonText;
                slider.ButtonUrl = command.ButtonUrl;
                slider.IsActive = command.IsActive;
                slider.Order = command.Order;
                await _context.SaveChangesAsync();
            }
        }
    }
}
