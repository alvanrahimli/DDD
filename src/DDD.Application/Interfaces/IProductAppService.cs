using System;
using System.Collections.Generic;
using DDD.Application.ViewModels;

namespace DDD.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        void Add(ProductViewModel newProduct);
        IEnumerable<ProductViewModel> GetAll();
        ProductViewModel GetById(Guid id);
    }
}
