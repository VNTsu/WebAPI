using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ass2.Model;
using Ass2.Data;
using Ass2.Service;
using Ass2.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Ass2.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("/Add")]
        public async Task Add(CategoryDTO category)
        {
            await _categoryService.Add(category);
        }

        [HttpPut("/edit-category")]
        public async Task Edit(Guid id,CategoryDTO category)
        {
            await _categoryService.Update(id,category);
        }

        [HttpDelete("/delete-category")]
        public async Task Delete(Guid id)
        {
            await _categoryService.Delete(id);
        }

        [HttpGet("/get-all-category")]
        public async Task<List<Category>> GetAllStudent()
        {
            return await _categoryService.GetAll();
        }
    }
}