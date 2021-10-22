using System;
using System.Collections.Generic;
using System.Linq;
using DDD.Application.ViewModels;

namespace DDD.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        void Add(ProductViewModel newProduct);
        IQueryable<ProductViewModel> GetAll();
        ProductViewModel GetById(Guid id);
        void Update(ProductViewModel updatedProduct);
    }
}
