using AutoMapper;
using CQRSProject.CQRSPattern.Commands.ProductCommands;
using CQRSProject.CQRSPattern.Results.ProductResults;
using CQRSProject.Entities;

namespace CQRSProject.Mappings
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            CreateMap<Product, GetProductsQueryResult>();
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<Product, GetProductByIdQueryResult>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
