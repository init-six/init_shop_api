using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace init_api.Entities
{
    public class ThirdCategory
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        public Guid UUID { get; set; }
        [Column(TypeName = "bigint")]
        public Int64 ParentId { get; set; }
        [Comment("category name")]
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public SecCategory Parent { get; set; } = new SecCategory();
    }
}
