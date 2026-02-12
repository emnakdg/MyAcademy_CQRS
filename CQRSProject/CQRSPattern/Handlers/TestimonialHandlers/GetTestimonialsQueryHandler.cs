using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.TestimonialResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.TestimonialHandlers
{
    public class GetTestimonialsQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetTestimonialsQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TestimonialResult>> Handle()
        {
            var values = await _context.Testimonials.ToListAsync();
            return _mapper.Map<List<TestimonialResult>>(values);
        }
    }
}
