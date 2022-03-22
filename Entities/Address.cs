using System.ComponentModel.DataAnnotations.Schema;
using init_api.Entities.Order;
namespace init_api.Entities
{
    public class Address
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        public Int64? fkOrderId { get; set; }
        public String? StreetAddress { get; set; }
        public String? Suburb { get; set; }
        public String? PostalCode { get; set; }
        public String? City { get; set; }
        public String? Country { get; set; }
        public Orders parent { get; set; } = new Orders();
        public Address()
        {
        }

    }
}
