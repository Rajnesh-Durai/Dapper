using MediatR;

namespace SampleProject.Application.Features.OrderDetail.Command
{
    public class CheckoutOrderItemsCommand : IRequest<string>
    {
        public int CustomerOrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
