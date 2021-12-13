using init_api.Entities;
using init_api.DtoParameters;

namespace init_api.Services
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(Guid categoryId);
        Task<IEnumerable<Category>> GetCategoriesAsync(IEnumerable<Guid> categoryIds);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        Task<bool> CategoryExistsAsync(Guid categoryId);
        Task<IEnumerable<Product>> GetProductsAsync(Guid categoryId,ProductDtoParameters parameters);
        Task<Product> GetProductAsync(Guid categoryId,Guid productId);
        void AddProduct(Guid categoryId, Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        Task<bool> SaveAsync();
    }
}
