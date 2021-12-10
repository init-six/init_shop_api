using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using init_api.Services;
using init_api.Models;
using init_api.Entities;
using init_api.Helpers;
namespace init_api.Controllers
{
    [ApiController]
    [Route("api/categoriescollection")]
    public class CategoriesCollectionController:ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoriesCollectionController(ICategoryRepository categoryRepository, IMapper mapper){
            _categoryRepository=categoryRepository??throw new ArgumentNullException(nameof(categoryRepository));
            _mapper=mapper??throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet("{ids}",Name=nameof(GetCategoryCollection))]
        public async Task<ActionResult> GetCategoryCollection(
                [FromRoute]
                [ModelBinder(BinderType=typeof(ArrayModelBinder))]
                IEnumerable<Guid> ids)
        {
            if (ids==null){
                return BadRequest();
            }
            var entities =await _categoryRepository.GetCategoriesAsync(ids);
            if (ids.Count()!=entities.Count()){
                return NotFound();
            }
            var returnDto=_mapper.Map<IEnumerable<CategoryDto>>(entities);
            return Ok(returnDto);

        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> CreateCategoryCollection(
            IEnumerable<CategoryAddDto> categoryCollection){
            var categoriesEntity=_mapper.Map<IEnumerable<Category>>(categoryCollection);
            foreach (var category in categoriesEntity){
                _categoryRepository.AddCategory(category);
            }
            await _categoryRepository.SaveAsync();
            var returnDto=_mapper.Map<IEnumerable<CategoryDto>>(categoriesEntity);
            var idsString=string.Join(",",returnDto.Select(x=>x.UUID));
            return CreatedAtRoute(nameof(GetCategoryCollection),new{ids=idsString},returnDto);
        }
    }
}
