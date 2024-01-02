namespace SampleProject.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailId { get; set; }
        public ICollection<CustomerOrder>? CustomerOrders { get; set; }
    }
}
