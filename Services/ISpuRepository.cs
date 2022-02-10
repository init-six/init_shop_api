using init_api.Entities;
using init_api.DtoParameters;
using init_api.Helpers;

namespace init_api.Services
{
    public interface ISpuRepository
    {
        Task<IEnumerable<Spu>>GetSpusAsync();
        Task<Spu>GetSpuAsync(Guid spuUUID);
        void AddSpu(Spu spu);
        void UpdateSpu(Spu spu);
        void DeleteSpu(Spu spu);
        Task<bool> SpuExistAsync(Guid spuUUID);
        Task<bool> SaveAsync();
    }
}
