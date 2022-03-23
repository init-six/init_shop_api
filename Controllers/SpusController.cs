using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using init_api.Services;
using init_api.Models;
using init_api.Entities.Product;
using init_api.QueryParameters;

namespace init_api.Controllers
{
    [ApiController]
    [Route("api/spus")]
    public class SpusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISpuRepository _spuRepository;
        private readonly ICategoryRepository _categoryRepository;
        public SpusController(IMapper map, ISpuRepository spuRepository, ICategoryRepository categoryRepository)
        {
            _mapper = map ?? throw new ArgumentNullException(nameof(map));
            _spuRepository = spuRepository ?? throw new ArgumentNullException(nameof(spuRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpuDto>>> GetSpus([FromQuery] SpusParameters parameters)
        {
            var spus = await _spuRepository.GetSpusAsync(parameters);
            var returnDtos = _mapper.Map<IEnumerable<SpuDto>>(spus);
            return Ok(returnDtos);
        }

        [HttpGet("{spuUUID}", Name = nameof(GetSpu))]
        public async Task<ActionResult<SpuDto>> GetSpu(Guid spuUUID)
        {
            if (!await _spuRepository.SpuExistAsync(spuUUID))
            {
                return NotFound();
            }
            var spu = await _spuRepository.GetSpuAsync(spuUUID);
            if (spu == null)
            {
                return NotFound();
            }
            var spuDto = _mapper.Map<SpuDto>(spu);
            return Ok(spuDto);
        }

        [HttpPost]
        public async Task<ActionResult<SpuDto>> CreateSpu(SpuAddDto spu)
        {
            var entity = _mapper.Map<Spu>(spu);
            //check linked categories
            if ((spu.Ct1 != Guid.Empty) && (spu.Ct1.HasValue) && (!await _categoryRepository.CategoryExistsAsync(spu.Ct1.Value)))
            {
                return NotFound();
            }
            if ((spu.Ct2 != Guid.Empty) && (spu.Ct2.HasValue) && (spu.Ct1.HasValue)
                    && (!await _categoryRepository.SecCategoryExistsAsync(spu.Ct1.Value, spu.Ct2.Value)))
            {
                return NotFound();
            }
            if ((spu.Ct3 != Guid.Empty) && (spu.Ct3.HasValue) && (spu.Ct2.HasValue)
                    && (!await _categoryRepository.ThirdCategoryExistsAsync(spu.Ct2.Value, spu.Ct3.Value)))
            {
                return NotFound();
            }
            _spuRepository.AddSpu(entity);
            await _spuRepository.SaveAsync();
            var returnDto = _mapper.Map<SpuDto>(entity);
            return CreatedAtRoute(nameof(GetSpu), new { spuUUID = returnDto.UUID }
                    , returnDto);
        }

        [HttpPut("{spuUUID}/saleable")]
        public async Task<IActionResult> UpdateSpuSaleAble(Guid spuUUID, SpuUpdateSaleAbleDto spuUpdateDto)
        {
            if (!await _spuRepository.SpuExistAsync(spuUUID))
            {
                return NotFound();
            }
            var entity = await _spuRepository.GetSpuAsync(spuUUID);
            if (entity == null)
            {
                return NotFound();
            }
            _mapper.Map(spuUpdateDto, entity);
            _spuRepository.UpdateSpu(entity);
            await _spuRepository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{spuUUID}")]
        public async Task<IActionResult> UpdateSpu(Guid spuUUID, SpuUpdateDto spuUpdateDto)
        {
            if (!await _spuRepository.SpuExistAsync(spuUUID))
            {
                return NotFound();
            }
            //check linked categories
            if ((spuUpdateDto.Ct1 != Guid.Empty) && (spuUpdateDto.Ct1.HasValue) && (!await _categoryRepository.CategoryExistsAsync(spuUpdateDto.Ct1.Value)))
            {
                return NotFound();
            }
            if ((spuUpdateDto.Ct2 != Guid.Empty) && (spuUpdateDto.Ct2.HasValue) && (spuUpdateDto.Ct1.HasValue)
                    && (!await _categoryRepository.SecCategoryExistsAsync(spuUpdateDto.Ct1.Value, spuUpdateDto.Ct2.Value)))
            {
                return NotFound();
            }
            if ((spuUpdateDto.Ct3 != Guid.Empty) && (spuUpdateDto.Ct3.HasValue) && (spuUpdateDto.Ct2.HasValue)
                    && (!await _categoryRepository.ThirdCategoryExistsAsync(spuUpdateDto.Ct2.Value, spuUpdateDto.Ct3.Value)))
            {
                return NotFound();
            }
            var entity = await _spuRepository.GetSpuAsync(spuUUID);
            if (entity == null)
            {
                return NotFound();
            }
            _mapper.Map(spuUpdateDto, entity);
            _spuRepository.UpdateSpu(entity);
            await _spuRepository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{spuUUID}")]
        public async Task<IActionResult> DeleteSpu(Guid spuUUID)
        {
            if (!await _spuRepository.SpuExistAsync(spuUUID))
            {
                return NotFound();
            }
            var entity = await _spuRepository.GetSpuAsync(spuUUID);
            if (entity == null)
            {
                return NotFound();
            }
            _spuRepository.DeleteSpu(entity);
            await _spuRepository.SaveAsync();
            return NoContent();
        }

    }
}
