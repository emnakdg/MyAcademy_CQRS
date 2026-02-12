using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.TestimonialResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetTestimonialByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TestimonialResult> Handle(int id)
        {
            var value = await _context.Testimonials.FindAsync(id);
            return _mapper.Map<TestimonialResult>(value);
        }
    }
}
