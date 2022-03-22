using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace init_api.Entities.Category
{
    public class Category
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        public Guid UUID { get; set; }
        [Comment("category name")]
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public ICollection<SecCategory> children { get; set; } = new List<SecCategory>();
    }
}
