using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Domain.Models
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Column(TypeName = "Date")]
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItems>? OrderItems { get; set; }
    }
}
