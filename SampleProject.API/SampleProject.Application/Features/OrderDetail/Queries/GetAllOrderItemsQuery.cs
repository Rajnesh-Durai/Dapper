using MediatR;
using SampleProject.Application.ViewModels;

namespace SampleProject.Application.Features.OrderDetail.Queries
{
    public record class GetAllOrderItemsQuery : IRequest<List<OrderItemsResponse>>;
}
