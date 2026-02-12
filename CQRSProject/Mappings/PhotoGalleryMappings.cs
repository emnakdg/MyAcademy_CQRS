using AutoMapper;
using CQRSProject.CQRSPattern.Results.PhotoGalleryResults;
using CQRSProject.Entities;

namespace CQRSProject.Mappings
{
    public class PhotoGalleryMappings : Profile
    {
        public PhotoGalleryMappings()
        {
            CreateMap<PhotoGallery, PhotoGalleryResult>();
        }
    }
}
