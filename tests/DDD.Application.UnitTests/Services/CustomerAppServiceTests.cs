using System;
using AutoMapper;
using DDD.Application.Services;
using DDD.Application.ViewModels;
using DDD.Domain.Interfaces;
using Moq;
using Xunit;

namespace DDD.Application.UnitTests.Services
{
    public class CustomerAppServiceTests
    {
        [Fact]
        public void GetById()
        {
            // Arrange
            var customer = new Domain.Models.Customer(new Guid(), "Nahid", "Jamalli", "Baku, AZ", "AZ1000", "nahidjamalli@test.com", new DateTime());

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.GetById(customer.Id))
                .Returns(customer);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<CustomerViewModel>(customer)).Returns(new CustomerViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                PostalCode = customer.PostalCode,
                Email = customer.Email,
                BirthDate = customer.BirthDate,
            });

            // Act
            var sut = new CustomerAppService(mapperMock.Object, customerRepositoryMock.Object, null, null);
            var result = sut.GetById(customer.Id);

            // Assert
            Assert.Equal(result.Id, customer.Id);
            Assert.Equal(result.FirstName, customer.FirstName);
            Assert.Equal(result.LastName, customer.LastName);
            Assert.Equal(result.Address, customer.Address);
            Assert.Equal(result.PostalCode, customer.PostalCode);
            Assert.Equal(result.Email, customer.Email);
            Assert.Equal(result.BirthDate, customer.BirthDate);
        }
    }
}
