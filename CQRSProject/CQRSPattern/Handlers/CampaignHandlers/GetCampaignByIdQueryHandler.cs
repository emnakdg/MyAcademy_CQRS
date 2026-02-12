using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.CampaignResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.CampaignHandlers
{
    public class GetCampaignByIdQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetCampaignByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CampaignResult> Handle(int id)
        {
            var value = await _context.Campaigns.FindAsync(id);
            return _mapper.Map<CampaignResult>(value);
        }
    }
}
