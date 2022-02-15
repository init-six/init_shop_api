using Microsoft.EntityFrameworkCore;
using init_api.Data;
using init_api.Entities;
using init_api.DtoParameters;
using init_api.Helpers;

namespace init_api.Services
{
    public class SpuRepository : ISpuRepository
    {
        private readonly ShopContext _context;
        public SpuRepository(ShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        //spu process
        public async Task<IEnumerable<Spu>> GetSpusAsync()
        {
            return await _context.Spu.ToListAsync();
        }
        public async Task<Spu> GetSpuAsync(Guid spuUUID)
        {
            if (spuUUID == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(spuUUID));
            }
            var res = await _context.Spu.FirstOrDefaultAsync(x => x.UUID == spuUUID);
            if (res != null)
            {
                var skus = await _context.Sku.Where(x => x.fkSpuId == res.Id).OrderBy(x => x.Name).ToListAsync();
                res.Skus = skus;
                var spudetail = await _context.SpuDetail.FirstOrDefaultAsync(x => x.fkSpuId == res.Id);
                res.SpuDetail = spudetail ?? new SpuDetail();
            }
            return res ?? new Spu();
        }
        public void AddSpu(Spu spu)
        {
            if (spu == null)
            {
                throw new ArgumentNullException(nameof(spu));
            }
            spu.UUID = Guid.NewGuid();
            if (spu.Skus != null)
            {
                foreach (var sku in spu.Skus)
                {
                    sku.UUID = Guid.NewGuid();
                }
            }
            _context.Spu.Add(spu);
        }
        public void UpdateSpu(Spu spu)
        {
            //_context.Entry(spu).State=EntityState.Modified;
        }

        public void UpdateSpuDetail(SpuDetail spudetail)
        {

        }

        public void DeleteSpu(Spu spu)
        {
            if (spu == null)
            {
                throw new ArgumentNullException(nameof(spu));
            }
            _context.Spu.Remove(spu);
        }
        public async Task<bool> SpuExistAsync(Guid spuUUID)
        {
            if (spuUUID == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(spuUUID));
            }
            return await _context.Spu.AnyAsync(x => x.UUID == spuUUID);
        }
        //sku process
        public async Task<Sku> GetSkuAsync(Guid spuUUID, Guid skuUUID)
        {
            if (spuUUID == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(spuUUID));
            }

            if (skuUUID == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(skuUUID));
            }

            var res = await _context.Sku.Where(x => x.Spu.UUID == spuUUID && x.UUID == skuUUID).FirstOrDefaultAsync();
            if (res != null)
            {
                var stock = await _context.Stock.Where(x => x.fkSkuId == res.Id).FirstOrDefaultAsync();
                res.Stock = stock ?? new Stock();
            }
            return res ?? new Sku();
        }

        //stock process
        public async Task<Stock> GetStockAsync(Guid skuUUID)
        {
            if (skuUUID == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(skuUUID));
            }

            var res = await _context.Stock.Where(x => x.Sku.UUID == skuUUID).FirstOrDefaultAsync();
            return res ?? new Stock();
        }

        public void AddSku(Guid spuUUID, Sku sku)
        {
            if (spuUUID == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(spuUUID));
            }
            var spu = _context.Spu.FirstOrDefault(x => x.UUID == spuUUID);
            if (sku == null)
            {
                throw new ArgumentNullException(nameof(sku));
            }
            sku.Spu = spu;
            sku.fkSpuId = spu.Id;
            sku.UUID = Guid.NewGuid();
            _context.Sku.Add(sku);
        }

        public void UpdateSku(Sku sku)
        {
        }

        public void UpdateStock(Stock stock)
        {
        }

        public void DeleteSku(Sku sku)
        {
            if (sku == null)
            {
                throw new ArgumentNullException(nameof(sku));
            }
            _context.Sku.Remove(sku);
        }

        public async Task<bool> SkuExistAsync(Guid skuUUID)
        {
            if (skuUUID == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(skuUUID));
            }
            return await _context.Sku.AnyAsync(x => x.UUID == skuUUID);
        }

        //save process
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
