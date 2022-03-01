using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ass2.DTO;
using Ass2.Model;

namespace Ass2.Service
{
    public interface IProductService
    {
        Task Add(ProductDTO product );
        Task Update(Guid id,ProductDTO product);
        Task Delete(Guid id);
        Task<List<Product>> GetAll();
    }
}