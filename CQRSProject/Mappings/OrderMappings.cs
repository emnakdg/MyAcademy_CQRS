using AutoMapper;
using CQRSProject.CQRSPattern.Results.OrderResults;
using CQRSProject.Entities;

namespace CQRSProject.Mappings
{
    public class OrderMappings : Profile
    {
        public OrderMappings()
        {
            CreateMap<Order, GetOrderQueryResult>();
            CreateMap<Order, GetOrderByIdQueryResult>();
            CreateMap<OrderItem, OrderItem>();
        }
    }
}
