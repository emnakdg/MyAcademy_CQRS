using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.CampaignResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.CampaignHandlers
{
    public class GetCampaignsQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetCampaignsQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CampaignResult>> Handle()
        {
            var values = await _context.Campaigns.ToListAsync();
            return _mapper.Map<List<CampaignResult>>(values);
        }
    }
}
