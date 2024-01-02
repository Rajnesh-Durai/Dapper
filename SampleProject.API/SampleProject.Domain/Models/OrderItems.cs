using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Domain.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        [ForeignKey("CustomerOrder")]
        public int CustomerOrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
