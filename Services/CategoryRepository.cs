using Microsoft.EntityFrameworkCore;
using init_api.Data;
using init_api.Entities;
namespace init_api.Services
{
    public class CategoryRepository:ICategoryRepository{
        private readonly ShopContext _context;
        public CategoryRepository(ShopContext context){
            _context=context??throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync(){
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category> GetCategoryAsync(Guid categoryId){
            if (categoryId==Guid.Empty){
                throw new ArgumentNullException(nameof(categoryId));
            }
            return await _context.Categories.FirstOrDefaultAsync(x=>x.UUID==categoryId);
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync(IEnumerable<Guid> categoryIds){
            if (categoryIds==null){
                throw new ArgumentNullException(nameof(categoryIds));
            }
            return await _context.Categories
                .Where(x=>categoryIds.Contains(x.UUID))
                .OrderBy(x=>x.Name).ToListAsync();
        }
        public void AddCategory(Category category){
            if (category==null){
                throw new ArgumentNullException(nameof(category));
            }
            category.UUID=Guid.NewGuid();
            if (category.Products!=null){
                foreach(var product in category.Products){
                    product.UUID=Guid.NewGuid();
                    product.CategoryId=category.UUID;
                }
            }
            _context.Categories.Add(category);
        }
        public void UpdateCategory(Category category){
            _context.Entry(category).State=EntityState.Modified;
        }
        public void DeleteCategory(Category category){
            if (category==null){
                throw new ArgumentNullException(nameof(category));
            }
            _context.Categories.Remove(category);
        }
        public async Task<bool> CategoryExistsAsync(Guid categoryId){
            if (categoryId==Guid.Empty){
                throw new ArgumentNullException(nameof(categoryId));
            }
            return await _context.Categories.AnyAsync(x=>x.UUID==categoryId);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(Guid categoryId){
            if (categoryId==Guid.Empty){
                throw new ArgumentNullException(nameof(categoryId));
            }

            return await _context.Products
                .Where(x=>x.CategoryId==categoryId)
                .OrderBy(x=>x.Name).ToListAsync();
        }
        public async Task<Product> GetProductAsync(Guid categoryId,Guid productId){
            if (productId==Guid.Empty||categoryId==Guid.Empty){
                throw new ArgumentNullException(nameof(productId),nameof(categoryId));
            }
            return await _context.Products.Where(x=>x.UUID==productId&&x.CategoryId==categoryId).FirstOrDefaultAsync();
        }
        public void AddProduct(Guid categoryId,Product product){
            if (categoryId==Guid.Empty){
                throw new ArgumentNullException(nameof(categoryId));
            }
            var category=_context.Categories.FirstOrDefault(x=>x.UUID==categoryId);
            if (product==null){
                throw new ArgumentNullException(nameof(product));
            }
            product.CategoryId=categoryId;
            product.FkCategoryId=category.Id;
            product.UUID=Guid.NewGuid();
            _context.Products.Add(product);
        }
        public void UpdateProduct(Product product){
            _context.Entry(product).State=EntityState.Modified;
        }
        public void DeleteProduct(Product product){ _context.Products.Remove(product);
        }
        public async Task<bool> SaveAsync(){
            return await _context.SaveChangesAsync()>=0;
        }
    }
}
