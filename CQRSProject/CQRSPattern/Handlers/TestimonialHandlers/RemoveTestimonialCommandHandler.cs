using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.TestimonialCommands;

namespace CQRSProject.CQRSPattern.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler
    {
        private readonly AppDbContext _context;

        public RemoveTestimonialCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveTestimonialCommand command)
        {
            var testimonial = await _context.Testimonials.FindAsync(command.Id);
            if (testimonial != null)
            {
                _context.Testimonials.Remove(testimonial);
                await _context.SaveChangesAsync();
            }
        }
    }
}
