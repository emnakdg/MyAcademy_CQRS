using AutoMapper;
using CQRSProject.CQRSPattern.Results.PromotionResults;
using CQRSProject.Entities;

namespace CQRSProject.Mappings
{
    public class PromotionMappings : Profile
    {
        public PromotionMappings()
        {
            CreateMap<Promotion, PromotionResult>();
        }
    }
}
