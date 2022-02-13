using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using init_api.Services;
using init_api.Models;
using init_api.Entities;

namespace init_api.Controllers
{
    [ApiController]
    [Route("api/spus")]
    public class SpusController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISpuRepository _spuRepository;
        public SpusController(IMapper map,ISpuRepository spuRepository){
            _mapper=map??throw new ArgumentNullException(nameof(map));
            _spuRepository=spuRepository??throw new ArgumentNullException(nameof(spuRepository));
        }

        [HttpGet("{spuUUID}",Name=nameof(GetSpu))]
        public async Task<ActionResult<SpuDto>> GetSpu(Guid spuUUID){
            if (! await _spuRepository.SpuExistAsync(spuUUID)){
                return NotFound();
            }
            var spu=await _spuRepository.GetSpuAsync(spuUUID);
            if (spu==null){
                return NotFound();
            }
            var spuDto=_mapper.Map<SpuDto>(spu);
            return Ok(spuDto);
        }
        [HttpPost]
        public async Task<ActionResult<SpuDto>> CreateSpu(SpuAddDto spu){
            var entity=_mapper.Map<Spu>(spu);
            _spuRepository.AddSpu(entity);
            await _spuRepository.SaveAsync();
            var returnDto=_mapper.Map<SpuDto>(entity);
            return CreatedAtRoute(nameof(GetSpu),new{spuUUID=returnDto.UUID}
                    ,returnDto);
        }
        [HttpPut("{spuUUID}")]
        public async Task<IActionResult> UpdateSpu(Guid spuUUID,SpuUpdateDto spuUpdateDto){
            if (! await _spuRepository.SpuExistAsync(spuUUID)){
                return NotFound();
            }
            var entity = await _spuRepository.GetSpuAsync(spuUUID);
            if (entity==null){
                return NotFound();
            }
            _mapper.Map(spuUpdateDto,entity);
            _spuRepository.UpdateSpu(entity);
            await _spuRepository.SaveAsync();
            return NoContent();
        }
        [HttpDelete("{spuUUID}")]
        public async Task<IActionResult> DeleteSpu(Guid spuUUID){
            if (!await _spuRepository.SpuExistAsync(spuUUID)){
                return NotFound();
            }
            var entity=await _spuRepository.GetSpuAsync(spuUUID);
            if (entity==null){
                return NotFound();
            }
            _spuRepository.DeleteSpu(entity);
            await _spuRepository.SaveAsync();
            return NoContent();
        }

    }
}
