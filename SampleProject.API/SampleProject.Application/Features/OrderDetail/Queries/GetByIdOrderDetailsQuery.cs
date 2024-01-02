using MediatR;
using SampleProject.Application.ViewModels;

namespace SampleProject.Application.Features.OrderDetail.Queries
{
    public class GetByIdOrderDetailsQuery : IRequest<OrderItemsResponse>
    {
        public int Id { get; set; }
        public GetByIdOrderDetailsQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
