using System.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ass2.Data;
using Ass2.DTO;
using Ass2.Model;
using Microsoft.EntityFrameworkCore;

namespace Ass2.Service
{

    public class CategoryService : ICategoryService
    {
        private Ass2Context _dbContext;
        public CategoryService(Ass2Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(CategoryDTO category)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var addcategory = await _dbContext.Categorie.AddAsync(new Category
                {
                    CategoryName = category.CategoryName,
                });

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                transaction.RollbackAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var item = await _dbContext.Categorie.FindAsync(id);
                if (item != null)
                {
                    _dbContext.Categorie.Remove(item);

                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public async Task<List<Category>> GetAll()
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                return await _dbContext.Categorie.ToListAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                transaction.Rollback();
                return null;
            }
        }

        public async Task Update(Guid id,CategoryDTO category)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var item = await _dbContext.Categorie.FindAsync(id);
                if (item != null)
                {
                    item.CategoryName = category.CategoryName;

                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

    }
}
