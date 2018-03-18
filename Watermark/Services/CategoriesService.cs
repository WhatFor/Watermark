using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watermark.Models.Products;
using Watermark.Repository.Contracts;
using Watermark.Services.Contracts;

namespace Watermark.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<List<ProductCategory>> GetProductCategoriesAsync()
        {
            return await categoriesRepository.GetProductCategoriesAsync();
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