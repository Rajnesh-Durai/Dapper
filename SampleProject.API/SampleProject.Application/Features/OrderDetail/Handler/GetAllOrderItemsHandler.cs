using AutoMapper;
using MediatR;
using SampleProject.Application.Features.OrderDetail.Queries;
using SampleProject.Application.ViewModels;
using SampleProject.Domain.Interface;
using SampleProject.Domain.Models;
using SampleProject.Domain.Service;

namespace SampleProject.Application.Features.OrderDetail.Handler
{
    public class GetAllOrderItemsHandler : IRequestHandler<GetAllOrderItemsQuery, List<OrderItemsResponse>>
    {
        private readonly IOrderDetailsRepository<OrderItems> repository;
        private readonly IMapper mapper;
        private readonly IServiceBusSender<OrderItemsResponse> serviceBusSender;
        public GetAllOrderItemsHandler(IOrderDetailsRepository<OrderItems> repository, IMapper mapper, IServiceBusSender<OrderItemsResponse> serviceBusSender)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.serviceBusSender = serviceBusSender;
        }
        public async Task<List<OrderItemsResponse>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
        {
            List<OrderItems> result = await this.repository.GetAllOrderDetails();
            var output = this.mapper.Map<List<OrderItemsResponse>>(result);
            await this.serviceBusSender.SendQueryListQueue(output);
            return output;
        }
    }
}
