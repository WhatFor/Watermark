using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watermark.Models.Products;
using Watermark.Repository.Contracts;

namespace Watermark.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly WatermarkDbContext dbContext;

        public CategoriesRepository(WatermarkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<ProductCategory>> GetProductCategoriesAsync()
        {
            return await dbContext.ProductCategory.ToListAsync();
        }

        public async Task<ProductCategory> GetProductCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductCategory> GetProductCategoryByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}