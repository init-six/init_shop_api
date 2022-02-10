using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace init_api.Entities
{
    public class Spu
    {
        [Column(TypeName="bigint")]
        //[DataType(DataType.Url)]
        public long Id {get;set;}
        public Guid UUID {get;set;}
        public string Name {get;set;}
        [Comment("first category")]
        public long? Ct1 {get;set;}
        [Comment("second category")]
        public long? Ct2 {get;set;}
        [Comment("third category")]
        public long? Ct3 {get;set;}
        [Comment("brand id")]
        public long? BrandId {get;set;}
        [Comment("0 offshore, 1 onshore; default 1;")]
        public int  Saleable {get;set;}
        [Comment("0 deleted, 1 valid; default: 1;")]
        public int Valid {get;set;}
        public DateTime CreateTime {get;set;}
        public DateTime LastUpdateTime {get;set;}
        public Spu(){
            this.Name="undefined";
            this.Saleable=1;
            this.Valid=1;
            this.CreateTime=DateTime.UtcNow;
            this.LastUpdateTime=DateTime.UtcNow;
        }
    }
}
