using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using init_api.Services;
using init_api.Models;
using init_api.Entities;

namespace init_api.Controllers
{
    [ApiController]
    [Route("api/spus/{spuUUID}/skus")]
    public class SkusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISpuRepository _spuRepository;
        public SkusController(IMapper map, ISpuRepository spuRepository)
        {
            _mapper = map ?? throw new ArgumentNullException(nameof(map));
            _spuRepository = spuRepository ?? throw new ArgumentNullException(nameof(spuRepository));
        }

        [HttpGet("{skuUUID}", Name = nameof(GetSku))]
        public async Task<ActionResult<SkuDto>> GetSku(Guid spuUUID, Guid skuUUID)
        {
            if (!await _spuRepository.SpuExistAsync(spuUUID))
            {
                return NotFound();
            }
            var sku = await _spuRepository.GetSkuAsync(spuUUID, skuUUID);
            if (sku == null)
            {
                return NotFound();
            }
            var skuDto = _mapper.Map<SkuDto>(sku);
            return Ok(skuDto);
        }

        [HttpPost]
        public async Task<ActionResult<SkuDto>> CreateSku(Guid spuUUID, SkuAddDto sku)
        {
            var entity = _mapper.Map<Sku>(sku);
            _spuRepository.AddSku(spuUUID, entity);
            await _spuRepository.SaveAsync();
            var returnDto = _mapper.Map<SkuDto>(entity);
            return CreatedAtRoute(nameof(GetSku), new { spuUUID, skuUUID = returnDto.UUID }
                    , returnDto);
        }

        [HttpPut("{skuUUID}")]
        public async Task<IActionResult> UpdateSku(Guid spuUUID, Guid skuUUID, SkuUpdateDto skuUpdateDto)
        {
            if (!await _spuRepository.SpuExistAsync(spuUUID))
            {
                return NotFound();
            }
            var entity = await _spuRepository.GetSkuAsync(spuUUID, skuUUID);
            if (entity == null)
            {
                return NotFound();
            }
            _mapper.Map(skuUpdateDto, entity);
            _spuRepository.UpdateSku(entity);
            await _spuRepository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{skuUUID}/stock")]
        public async Task<IActionResult> UpdateStock(Guid skuUUID, StockUpdateDto stockUpdateDto)
        {

            var entity = await _spuRepository.GetStockAsync(skuUUID);
            if (entity == null)
            {
                return NotFound();
            }

            _mapper.Map(stockUpdateDto, entity);
            _spuRepository.UpdateStock(entity);
            await _spuRepository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{skuUUID}")]
        public async Task<IActionResult> DeleteSku(Guid spuUUID, Guid skuUUID)
        {
            if (!await _spuRepository.SpuExistAsync(spuUUID))
            {
                return NotFound();
            }
            var entity = await _spuRepository.GetSkuAsync(spuUUID, skuUUID);
            if (entity == null)
            {
                return NotFound();
            }
            _spuRepository.DeleteSku(entity);
            await _spuRepository.SaveAsync();
            return NoContent();
        }
    }
}
