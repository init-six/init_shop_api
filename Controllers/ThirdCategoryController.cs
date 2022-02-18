using Microsoft.AspNetCore.Mvc;
using init_api.Services;
using AutoMapper;
using init_api.Models;
using init_api.Entities;

namespace init_api.Controllers
{
    [ApiController]
    [Route("api/sec_categories/{sec_Id}/third_categories")]
    public class ThirdCategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public ThirdCategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{categoryId}", Name = nameof(GetThirdCategory))]
        public async Task<ActionResult<ThirdCategoryDto>> GetThirdCategory(Guid categoryId)
        {
            var category = await _categoryRepository.GetThirdCategoryAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ThirdCategoryDto>(category));
        }

        [HttpPost]
        public async Task<ActionResult<ThirdCategoryDto>> CreateThirdCategory(Guid sec_Id, ThirdCategoryAddDto category)
        {
            var parent = await _categoryRepository.GetSecCategoryAsync(sec_Id);
            if (parent == null)
            {
                return NotFound();
            }
            var entity = _mapper.Map<ThirdCategory>(category);
            entity.Parent = parent;
            entity.ParentId = parent.Id;
            _categoryRepository.AddThirdCategory(entity);
            await _categoryRepository.SaveAsync();
            var returnDto = _mapper.Map<ThirdCategoryDto>(entity);
            //return CreatedAtRoute(nameof(GetThirdCategory), new { categoryId = returnDto.UUID }, returnDto);
            return Ok(returnDto);
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateThirdCategory(Guid categoryId, ThirdCategoryUpdateDto categoryUpdate)
        {
            var category = await _categoryRepository.GetThirdCategoryAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            _mapper.Map(categoryUpdate, category);
            _categoryRepository.UpdateThirdCategory(category);
            await _categoryRepository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteThirdCategory(Guid categoryId)
        {
            var category = await _categoryRepository.GetThirdCategoryAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            _categoryRepository.DeleteThirdCategory(category);
            await _categoryRepository.SaveAsync();
            return NoContent();
        }
    }
}
