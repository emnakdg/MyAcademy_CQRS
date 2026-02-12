using AutoMapper;
using CQRSProject.CQRSPattern.Results.CategoryResults;
using CQRSProject.Entities;

namespace CQRSProject.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, GetCategoriesQueryResult>();
        }
    }
}
