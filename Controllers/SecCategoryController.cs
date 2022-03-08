using Microsoft.AspNetCore.Mvc;
using init_api.Services;
using AutoMapper;
using init_api.Models;
using init_api.Entities;
using Microsoft.AspNetCore.Authorization;

namespace init_api.Controllers
{
    [ApiController]
    [Route("api/category/{category_id}/sec_categories")]
    [Authorize(Roles = "User,Admin")]
    public class SecCategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public SecCategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //[HttpGet("{secCategoryId}", Name = nameof(GetSecCategory))]
        [HttpGet("{secUUID}")]
        public async Task<ActionResult<SecCategoryDto>> GetSecCategory(Guid secUUID)
        {
            var category = await _categoryRepository.GetSecCategoryAsync(secUUID);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SecCategoryDto>(category));
        }

        [HttpPost]
        public async Task<ActionResult<SecCategoryDto>> CreateSecCategory(Guid category_id, SecCategoryAddDto category)
        {
            var parent = await _categoryRepository.GetCategoryAsync(category_id);
            if (parent == null)
            {
                return NotFound();
            }
            var entity = _mapper.Map<SecCategory>(category);
            entity.Parent = parent;
            entity.ParentId = parent.Id;
            _categoryRepository.AddSecCategory(entity);
            await _categoryRepository.SaveAsync();
            var returnDto = _mapper.Map<SecCategoryDto>(entity);
            //return CreatedAtRoute(nameof(GetSecCategory), new { secUUID = returnDto.UUID}, returnDto);
            return Ok(returnDto);
        }

        [HttpPut("{sec_categoryId}")]
        public async Task<IActionResult> UpdateSecCategory(Guid sec_categoryId, SecCategoryUpdateDto categoryUpdate)
        {
            var category = await _categoryRepository.GetSecCategoryAsync(sec_categoryId);
            if (category == null)
            {
                return NotFound();
            }
            _mapper.Map(categoryUpdate, category);
            _categoryRepository.UpdateSecCategory(category);
            await _categoryRepository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{sec_categoryId}")]
        public async Task<IActionResult> DeleteSecCategory(Guid sec_categoryId)
        {
            var category = await _categoryRepository.GetSecCategoryAsync(sec_categoryId);
            if (category == null)
            {
                return NotFound();
            }
            _categoryRepository.DeleteSecCategory(category);
            await _categoryRepository.SaveAsync();
            return NoContent();
        }
    }
}
