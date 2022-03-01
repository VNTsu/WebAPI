using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ass2.DTO;
using Ass2.Model;

namespace Ass2.Service
{
    public interface ICategoryService
    {
        Task Add(CategoryDTO category);
        Task Update(Guid id,CategoryDTO category);
        Task Delete(Guid id);
        Task<List<Category>> GetAll();
    }
}