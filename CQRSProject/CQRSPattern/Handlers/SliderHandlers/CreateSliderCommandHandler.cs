using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.SliderCommands;
using CQRSProject.Entities;

namespace CQRSProject.CQRSPattern.Handlers.SliderHandlers
{
    public class CreateSliderCommandHandler
    {
        private readonly AppDbContext _context;

        public CreateSliderCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateSliderCommand command)
        {
            var slider = new Slider
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl,
                ButtonText = command.ButtonText,
                ButtonUrl = command.ButtonUrl,
                IsActive = command.IsActive,
                Order = command.Order
            };
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
        }
    }
}
