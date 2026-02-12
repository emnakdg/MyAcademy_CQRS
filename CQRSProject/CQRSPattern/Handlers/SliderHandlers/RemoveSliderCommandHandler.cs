using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.SliderCommands;

namespace CQRSProject.CQRSPattern.Handlers.SliderHandlers
{
    public class RemoveSliderCommandHandler
    {
        private readonly AppDbContext _context;

        public RemoveSliderCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveSliderCommand command)
        {
            var slider = await _context.Sliders.FindAsync(command.Id);
            if (slider != null)
            {
                _context.Sliders.Remove(slider);
                await _context.SaveChangesAsync();
            }
        }
    }
}
