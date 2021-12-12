using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using init_api.Services;
using init_api.Models;
using init_api.Entities;


namespace init_api.Controllers
{
    [ApiController]
    [Route("api/categories/{categoryId}/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public ProductsController(IMapper map, ICategoryRepository categoryRepository){
            _mapper=map??throw new ArgumentNullException(nameof(map));
            _categoryRepository=categoryRepository??throw new ArgumentNullException(nameof(categoryRepository));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsForCategory(Guid categoryId){
            if (! await _categoryRepository.CategoryExistsAsync(categoryId)){
                return NotFound();
            }
            var products=await _categoryRepository.GetProductsAsync(categoryId);
            var productDtos=_mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }
        [HttpGet("{productId}",Name=nameof(GetProductForCategory))]
        public async Task<ActionResult<ProductDto>> GetProductForCategory(Guid categoryId,Guid productId){
            if(! await _categoryRepository.CategoryExistsAsync(categoryId)){
                return NotFound();
            }
            var product =await _categoryRepository.GetProductAsync(categoryId,productId);
            if (product==null){
                return NotFound();
            }
            var productDto=_mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProductForCategory(Guid categoryId,ProductAddDto product){
            if (!await _categoryRepository.CategoryExistsAsync(categoryId)){
                return NotFound();
            }
            var entity=_mapper.Map<Product>(product);
            _categoryRepository.AddProduct(categoryId,entity);
            await _categoryRepository.SaveAsync();
            var returnDto=_mapper.Map<ProductDto>(entity);
            return CreatedAtRoute(nameof(GetProductForCategory),new
                    {
                        categoryId,
                        productId=returnDto.UUID
                    },
                    returnDto);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProductForCategory(Guid categoryId,
                Guid productId,
                ProductUpdateDto productUpdate)
        {
            if(! await _categoryRepository.CategoryExistsAsync(categoryId)){
                return NotFound();
            }
            var product =await _categoryRepository.GetProductAsync(categoryId,productId);
            if (product==null){
                return NotFound();
            }
            _mapper.Map(productUpdate,product);
            _categoryRepository.UpdateProduct(product);
            await _categoryRepository.SaveAsync();
            return NoContent();
        }

    }
}
