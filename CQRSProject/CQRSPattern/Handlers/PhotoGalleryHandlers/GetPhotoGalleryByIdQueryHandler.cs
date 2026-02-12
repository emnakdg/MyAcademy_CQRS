using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.PhotoGalleryResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.PhotoGalleryHandlers
{
    public class GetPhotoGalleryByIdQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetPhotoGalleryByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PhotoGalleryResult> Handle(int id)
        {
            var value = await _context.PhotoGalleries.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<PhotoGalleryResult>(value);
        }
    }
}
