using MediatR;

namespace SampleProject.Application.Features.OrderDetail.Command
{
    public class UpdateOrderItemsCommand : IRequest<string>
    {
        public int Id { get; set; }
        public int CustomerOrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
