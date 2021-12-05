using Microsoft.AspNetCore.Mvc;
using init_api.Services;
using AutoMapper;
using init_api.Models;

namespace init_api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController:ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper){
            _categoryRepository=categoryRepository??throw new ArgumentNullException(nameof(categoryRepository));
            _mapper=mapper??throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories=await _categoryRepository.GetCategoriesAsync();

            var categoriesDto= _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(categoriesDto);
        }
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(Guid categoryId){
            var category=await _categoryRepository.GetCategoryAsync(categoryId);
            if (category==null){
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryDto>(category));
        }

    }
}
