using Microsoft.EntityFrameworkCore;
using init_api.Data;
using init_api.Entities;
using init_api.DtoParameters;
using init_api.Helpers;

namespace init_api.Services
{
    public class SpuRepository:ISpuRepository{
        private readonly ShopContext _context;
        public SpuRepository(ShopContext context){
            _context=context??throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Spu>>GetSpusAsync(){
            return await _context.Spu.ToListAsync();
        }
        public async Task<Spu>GetSpuAsync(Guid spuUUID){
            if (spuUUID==Guid.Empty){
                throw new ArgumentNullException(nameof(spuUUID));
            }
            return await _context.Spu.FirstOrDefaultAsync(x=>x.UUID==spuUUID);
        }
        public void AddSpu(Spu spu){
            if (spu==null){
                throw new ArgumentNullException(nameof(spu));
            }
            spu.UUID=Guid.NewGuid();
            _context.Spu.Add(spu);
        }
        public void UpdateSpu(Spu spu){
            //_context.Entry(spu).State=EntityState.Modified;
        }
        public void DeleteSpu(Spu spu){
            if (spu==null){
                throw new ArgumentNullException(nameof(spu));
            }
            _context.Spu.Remove(spu);
        }
        public async Task<bool> SpuExistAsync(Guid spuUUID){
            if (spuUUID==Guid.Empty){
                throw new ArgumentNullException(nameof(spuUUID));
            }
            return await _context.Spu.AnyAsync(x=>x.UUID==spuUUID);
        }
        public async Task<bool> SaveAsync(){
            return await _context.SaveChangesAsync()>=0;
        }
    }
}
