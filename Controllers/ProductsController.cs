using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using init_api.Services;
using init_api.Models;
using init_api.Entities;
using init_api.DtoParameters;
using init_api.Helpers;
using System.Text.Json;
using System.Text.Encodings.Web;

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

        [HttpGet(Name=nameof(GetProductsForCategory))]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsForCategory(Guid categoryId,[FromQuery]ProductDtoParameters parameters){
            if (! await _categoryRepository.CategoryExistsAsync(categoryId)){
                return NotFound();
            }
            var products=await _categoryRepository.GetProductsAsync(categoryId,parameters);
            var previousPageLink=products.HasPreviouse?CreateProductsResourceUri(parameters,ResourceUriType.PreviousPage):null;
            var nextPageLink=products.HasNext?CreateProductsResourceUri(parameters,ResourceUriType.NextPage):null;
            var paginationMetadata=new
            {
                totalCount=products.TotalCount,
                pageSize=products.PageSize,
                currentPage=products.CurrentPage,
                totalPages=products.TotalPages,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(paginationMetadata,
                new JsonSerializerOptions{
                    Encoder=JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            }));

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
        
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProductForCategory(Guid categoryId,Guid productId){
            if(! await _categoryRepository.CategoryExistsAsync(categoryId)){
                return NotFound();
            }
            var product =await _categoryRepository.GetProductAsync(categoryId,productId);
            if (product==null){
                return NotFound();
            }

            _categoryRepository.DeleteProduct(product);
            await _categoryRepository.SaveAsync();
            return NoContent();
        }

        private string CreateProductsResourceUri(ProductDtoParameters parameters,ResourceUriType type){
            switch(type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link(nameof(GetProductsForCategory),
                            new{
                                pageNumber=parameters.PageNumber-1,
                                pageSize=parameters.PageSize,
                                pageName=parameters.ProductName,
                            });
                case ResourceUriType.NextPage:
                    return Url.Link(nameof(GetProductsForCategory),
                            new{
                                pageNumber=parameters.PageNumber+1,
                                pageSize=parameters.PageSize,
                                pageName=parameters.ProductName,
                            });
                default:
                    return Url.Link(nameof(GetProductsForCategory),
                            new{
                                pageNumber=parameters.PageNumber,
                                pageSize=parameters.PageSize,
                                pageName=parameters.ProductName,
                            });

            }
        }
    }
}
