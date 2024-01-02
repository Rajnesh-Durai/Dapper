using MediatR;

namespace SampleProject.Application.Features.OrderDetail.Command
{
    public class DeleteOrderItemsCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
