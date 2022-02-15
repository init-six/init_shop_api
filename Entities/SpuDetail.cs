using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace init_api.Entities
{
    [Comment("Spu Detail: Standard Product Unit")]
    public class SpuDetail
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        [Column(TypeName = "bigint")]
        public Int64 fkSpuId { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "varchar(3000)")]
        public string Specifications { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string SpecTemplate { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string PackingList { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string AfterService { get; set; }
        public Spu Spu { get; set; }
        public SpuDetail()
        {
            this.Description = "";
            this.Specifications = "";
            this.SpecTemplate = "";
            this.PackingList = "";
        }
    }
}
