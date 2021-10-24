using AutoMapper;
using DDD.Application.ViewModels;
using DDD.Domain.Models;

namespace DDD.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Product, ProductViewModel>();

            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderItem, OrderItemViewModel>()
                .ForMember(b => b.ProductName, x => x.MapFrom(a => a.Product.Name))
                .ForMember(b => b.ProductId, x => x.MapFrom(a => a.ProductId))
                .ForMember(b => b.TotalPrice, x => x.MapFrom(a => a.Count * a.Product.Price));
        }
    }
}
