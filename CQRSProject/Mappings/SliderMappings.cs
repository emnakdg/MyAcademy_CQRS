using AutoMapper;
using CQRSProject.CQRSPattern.Results.SliderResults;
using CQRSProject.Entities;

namespace CQRSProject.Mappings
{
    public class SliderMappings : Profile
    {
        public SliderMappings()
        {
            CreateMap<Slider, SliderResult>();
        }
    }
}
