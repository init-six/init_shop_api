using init_api.Entities.Category;

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
        Task<bool> CategoryExistBindSpuAsync(Guid categoryId);

        //sec category
        Task<SecCategory> GetSecCategoryAsync(Guid categoryId);
        void AddSecCategory(SecCategory category);
        void UpdateSecCategory(SecCategory category);
        void DeleteSecCategory(SecCategory category);
        Task<bool> SecCategoryExistsAsync(Guid parentId, Guid categoryId);
        Task<bool> SecCategoryExistBindSpuAsync(Guid categoryId);

        //third category
        Task<ThirdCategory> GetThirdCategoryAsync(Guid categoryId);
        void AddThirdCategory(ThirdCategory category);
        void UpdateThirdCategory(ThirdCategory category);
        void DeleteThirdCategory(ThirdCategory category);
        Task<bool> ThirdCategoryExistsAsync(Guid secCategoryId, Guid categoryId);
        Task<bool> SaveAsync();
        Task<bool> ThirdCategoryExistBindSpuAsync(Guid categoryId);
    }
}
