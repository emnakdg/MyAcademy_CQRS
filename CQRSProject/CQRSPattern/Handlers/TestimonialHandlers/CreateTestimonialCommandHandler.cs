using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.TestimonialCommands;
using CQRSProject.Entities;

namespace CQRSProject.CQRSPattern.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler
    {
        private readonly AppDbContext _context;

        public CreateTestimonialCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateTestimonialCommand command)
        {
            var testimonial = new Testimonial
            {
                CustomerName = command.CustomerName,
                CustomerTitle = command.CustomerTitle,
                Comment = command.Comment,
                ImageUrl = command.ImageUrl,
                Rating = command.Rating
            };
            await _context.Testimonials.AddAsync(testimonial);
            await _context.SaveChangesAsync();
        }
    }
}
