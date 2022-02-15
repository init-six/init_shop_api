using init_api.Entities;
using init_api.DtoParameters;
using init_api.Helpers;

namespace init_api.Services
{
    public interface ISpuRepository
    {
        //spu process
        Task<IEnumerable<Spu>> GetSpusAsync(); //uses under category
        Task<Spu> GetSpuAsync(Guid spuUUID);
        void AddSpu(Spu spu);
        void UpdateSpu(Spu spu);
        void UpdateSpuDetail(SpuDetail spudetail);
        void DeleteSpu(Spu spu);
        Task<bool> SpuExistAsync(Guid spuUUID);

        //sku process
        Task<Sku> GetSkuAsync(Guid spuUUID, Guid skuUUID);
        void AddSku(Guid spuUUID, Sku spu);
        void UpdateSku(Sku sku);
        void DeleteSku(Sku sku);
        Task<bool> SkuExistAsync(Guid skuUUID);

        Task<Stock> GetStockAsync(Guid skuUUID);
        void UpdateStock(Stock stock);
        //save changes
        Task<bool> SaveAsync();
    }
}
