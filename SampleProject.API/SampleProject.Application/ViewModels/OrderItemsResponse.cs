namespace SampleProject.Application.ViewModels
{
    public class OrderItemsResponse
    {
        public int Id { get; set; }
        public int CustomerOrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
