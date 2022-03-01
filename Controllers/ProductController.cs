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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("/Add-product")]
        public async Task Add(ProductDTO product)
        {
            await _productService.Add(product);
        }

        [HttpPut("/edit-product")]
        public async Task Edit(Guid id,ProductDTO product)
        {
            await _productService.Update(id,product);
        }

        [HttpDelete("/delete-product")]
        public async Task Delete(Guid id)
        {
            await _productService.Delete(id);
        }

        [HttpGet("/get-all-product")]
        public async Task<List<Product>> GetAllStudent()
        {
            return await _productService.GetAll();
        }
    }
}