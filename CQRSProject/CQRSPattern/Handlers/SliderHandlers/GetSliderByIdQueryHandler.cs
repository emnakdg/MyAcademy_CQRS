using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.SliderResults;

namespace CQRSProject.CQRSPattern.Handlers.SliderHandlers
{
    public class GetSliderByIdQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetSliderByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SliderResult> Handle(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            return _mapper.Map<SliderResult>(slider);
        }
    }
}
