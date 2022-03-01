using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ass2.DTO;
using Ass2.Model;
using Microsoft.EntityFrameworkCore;
using Ass2.Data;


namespace Ass2.Service
{
    public class ProductService : IProductService
    {
        private Ass2Context _dbContext;
        public ProductService(Ass2Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(ProductDTO product)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var addproduct = await _dbContext.Products.AddAsync(new Product
                {
                    ProductName = product.ProductName,
                    Manufacture = product.Manufacture,
                    CategoryID = product.CategoryID,
                });

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public async Task Delete(Guid id)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var item = await _dbContext.Products.FindAsync(id);
                if (item != null)
                {
                    _dbContext.Products.Remove(item);

                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public async Task<List<Product>> GetAll()
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                return await _dbContext.Products.ToListAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                transaction.Rollback();
                return null;
            }
        }

        public async Task Update(Guid id,ProductDTO product)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var categoryCheck = await _dbContext.Categorie.FindAsync(product.CategoryID);
                if (categoryCheck != null)
                {
                    var item = await _dbContext.Products.FindAsync(id);
                    if (item != null)
                    {
                        item.ProductName = product.ProductName;
                        item.Manufacture = product.Manufacture;

                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }
    }
}