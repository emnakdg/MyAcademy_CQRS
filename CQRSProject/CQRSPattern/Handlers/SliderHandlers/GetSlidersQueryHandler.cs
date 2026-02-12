using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.SliderResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.SliderHandlers
{
    public class GetSlidersQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetSlidersQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SliderResult>> Handle()
        {
            var sliders = await _context.Sliders
                .Where(x => x.IsActive)
                .OrderBy(x => x.Order)
                .ToListAsync();
            return _mapper.Map<List<SliderResult>>(sliders);
        }
    }
}
