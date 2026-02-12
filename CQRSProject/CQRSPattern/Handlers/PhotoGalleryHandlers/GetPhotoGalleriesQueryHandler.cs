using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.PhotoGalleryResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.PhotoGalleryHandlers
{
    public class GetPhotoGalleriesQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetPhotoGalleriesQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PhotoGalleryResult>> Handle()
        {
            var values = await _context.PhotoGalleries.Include(x => x.Category).ToListAsync();
            return _mapper.Map<List<PhotoGalleryResult>>(values);
        }
    }
}
