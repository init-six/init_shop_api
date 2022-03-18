using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using init_api.Services;
using AutoMapper;
using init_api.Models;
using init_api.Entities;

namespace init_api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [Authorize(Roles = "User,Admin")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();

            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(categoriesDto);
        }
        [HttpGet("{categoryId}", Name = nameof(GetCategory))]
        public async Task<ActionResult<CategoryDto>> GetCategory(Guid categoryId)
        {
            var category = await _categoryRepository.GetCategoryAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryAddDto category)
        {
            var entity = _mapper.Map<Category>(category);
            _categoryRepository.AddCategory(entity);
            await _categoryRepository.SaveAsync();
            var returnDto = _mapper.Map<CategoryDto>(entity);
            return CreatedAtRoute(nameof(GetCategory), new { categoryId = returnDto.UUID }, returnDto);
        }
        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(Guid categoryId, CategoryUpdateDto categoryUpdate)
        {
            var category = await _categoryRepository.GetCategoryAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            _mapper.Map(categoryUpdate, category);
            _categoryRepository.UpdateCategory(category);
            await _categoryRepository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            var category = await _categoryRepository.GetCategoryAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            if (await _categoryRepository.CategoryExistBindSpuAsync(categoryId))
            {
                return BadRequest("this category bind with other spus, please delete first.");
            }
            _categoryRepository.DeleteCategory(category);
            await _categoryRepository.SaveAsync();
            return NoContent();
        }
    }
}
