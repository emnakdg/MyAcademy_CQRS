using AutoMapper;
using CQRSProject.CQRSPattern.Results.TestimonialResults;
using CQRSProject.Entities;

namespace CQRSProject.Mappings
{
    public class TestimonialMappings : Profile
    {
        public TestimonialMappings()
        {
            CreateMap<Testimonial, TestimonialResult>();
        }
    }
}
