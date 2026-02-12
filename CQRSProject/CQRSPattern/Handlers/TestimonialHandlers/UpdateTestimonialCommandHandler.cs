using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.TestimonialCommands;

namespace CQRSProject.CQRSPattern.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler
    {
        private readonly AppDbContext _context;

        public UpdateTestimonialCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateTestimonialCommand command)
        {
            var testimonial = await _context.Testimonials.FindAsync(command.Id);
            if (testimonial != null)
            {
                testimonial.CustomerName = command.CustomerName;
                testimonial.CustomerTitle = command.CustomerTitle;
                testimonial.Comment = command.Comment;
                testimonial.ImageUrl = command.ImageUrl;
                testimonial.Rating = command.Rating;
                await _context.SaveChangesAsync();
            }
        }
    }
}
