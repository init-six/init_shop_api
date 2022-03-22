using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace init_api.Entities.Category
{
    public class SecCategory
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        [Column(TypeName = "bigint")]
        public Int64 ParentId { get; set; }
        public Guid UUID { get; set; }
        [Comment("category name")]
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public Category Parent { get; set; } = new Category();
        public ICollection<ThirdCategory> Children { get; set; } = new List<ThirdCategory>();
    }
}
