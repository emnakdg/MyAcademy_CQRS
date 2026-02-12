using AutoMapper;
using CQRSProject.CQRSPattern.Results.CampaignResults;
using CQRSProject.Entities;

namespace CQRSProject.Mappings
{
    public class CampaignMappings : Profile
    {
        public CampaignMappings()
        {
            CreateMap<Campaign, CampaignResult>();
        }
    }
}
