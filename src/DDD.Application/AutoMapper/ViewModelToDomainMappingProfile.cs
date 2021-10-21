using AutoMapper;
using DDD.Application.ViewModels;
using DDD.Domain.Commands;

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
        }
    }
}
