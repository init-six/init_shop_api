using Microsoft.EntityFrameworkCore;
using init_api.Data;
using init_api.Entities;
namespace init_api.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _context;
        public CategoryRepository(ShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.UUID == categoryId) ?? new Category();
            category.children = await _context.SecCategories.Where(x => x.ParentId == category.Id).ToListAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(IEnumerable<Guid> categoryIds)
        {
            if (categoryIds == null)
            {
                throw new ArgumentNullException(nameof(categoryIds));
            }
            return await _context.Categories
                .Where(x => categoryIds.Contains(x.UUID))
                .OrderBy(x => x.Name).ToListAsync();
        }
        public void AddCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            category.UUID = Guid.NewGuid();
            if (category.children != null)
            {
                foreach (var sec in category.children)
                {
                    sec.UUID = Guid.NewGuid();
                    if (sec.Children != null)
                    {
                        foreach (var third in sec.Children)
                        {
                            third.UUID = Guid.NewGuid();
                        }

                    }
                }
            }
            _context.Categories.Add(category);
        }
        public void UpdateCategory(Category category)
        {
            //_context.Entry(category).State=EntityState.Modified;
        }
        public void DeleteCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _context.Categories.Remove(category);
        }
        public async Task<bool> CategoryExistBindSpuAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }
            return await _context.Spu.AnyAsync(x => x.Ct1 == categoryId);
        }
        public async Task<bool> CategoryExistsAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }
            return await _context.Categories.AnyAsync(x => x.UUID == categoryId);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        //sec category process
        public async Task<SecCategory> GetSecCategoryAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }
            var category = await _context.SecCategories.FirstOrDefaultAsync(x => x.UUID == categoryId) ?? new SecCategory();
            category.Children = await _context.ThirdCategories.Where(x => x.ParentId == category.Id).ToListAsync();
            return category;
        }

        public void AddSecCategory(SecCategory category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            category.UUID = Guid.NewGuid();
            if (category.Children != null)
            {
                foreach (var third in category.Children)
                {
                    third.UUID = Guid.NewGuid();
                }
            }
            _context.SecCategories.Add(category);
        }

        public void UpdateSecCategory(SecCategory category)
        {
            //_context.Entry(category).State=EntityState.Modified;
        }

        public void DeleteSecCategory(SecCategory category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _context.SecCategories.Remove(category);
        }
        public async Task<bool> SecCategoryExistBindSpuAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }
            return await _context.Spu.AnyAsync(x => x.Ct2 == categoryId);
        }
        public async Task<bool> SecCategoryExistsAsync(Guid parentId, Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }
            return await _context.SecCategories.AnyAsync(x => x.UUID == categoryId && x.Parent.UUID == parentId);
        }

        //third category process
        public async Task<ThirdCategory> GetThirdCategoryAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }
            return await _context.ThirdCategories.FirstOrDefaultAsync(x => x.UUID == categoryId) ?? new ThirdCategory();
        }

        public void AddThirdCategory(ThirdCategory category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            category.UUID = Guid.NewGuid();
            _context.ThirdCategories.Add(category);
        }

        public void UpdateThirdCategory(ThirdCategory category)
        {
            //_context.Entry(category).State=EntityState.Modified;
        }
        public void DeleteThirdCategory(ThirdCategory category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _context.ThirdCategories.Remove(category);
        }
        public async Task<bool> ThirdCategoryExistBindSpuAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }
            return await _context.Spu.AnyAsync(x => x.Ct3 == categoryId);
        }

        public async Task<bool> ThirdCategoryExistsAsync(Guid secCategoryId, Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }
            return await _context.ThirdCategories.AnyAsync(x => x.UUID == categoryId && x.Parent.UUID == secCategoryId);
        }
    }
}
