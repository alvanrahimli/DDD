using AutoMapper;
using DDD.Application.ViewModels;
using DDD.Domain.Commands;
using DDD.Domain.Commands.Product;

namespace DDD.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.FirstName, c.LastName, c.Address, c.PostalCode, c.Email, c.BirthDate));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.FirstName, c.LastName, c.Address, c.PostalCode, c.Email, c.BirthDate));
            CreateMap<ProductViewModel, AddNewProductCommand>()
                .ConstructUsing(p => new AddNewProductCommand(p.Name, p.Price));
            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(p => new UpdateProductCommand(p.Id, p.Name, p.Price));

        }
    }
}
