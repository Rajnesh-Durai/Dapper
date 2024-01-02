using AutoMapper;
using MediatR;
using SampleProject.Application.Features.OrderDetail.Queries;
using SampleProject.Application.ViewModels;
using SampleProject.Domain.Interface;
using SampleProject.Domain.Models;
using SampleProject.Domain.Service;

namespace SampleProject.Application.Features.OrderDetail.Handler
{
    public class GetByIdOrderItemsHandler : IRequestHandler<GetByIdOrderDetailsQuery, OrderItemsResponse>
    {
        private readonly IOrderDetailsRepository<OrderItems> repository;
        private readonly IMapper mapper;
        private readonly IServiceBusSender<OrderItemsResponse> serviceBusSender;
        public GetByIdOrderItemsHandler(IOrderDetailsRepository<OrderItems> repository, IMapper mapper, IServiceBusSender<OrderItemsResponse> serviceBusSender)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.serviceBusSender = serviceBusSender;
        }
        public async Task<OrderItemsResponse> Handle(GetByIdOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            OrderItems response = await this.repository.GetByIdOrderDetails(request.Id);
            var output= this.mapper.Map<OrderItemsResponse>(response);
            await this.serviceBusSender.SendQueryQueue(output);
            return output;

        }
    }
}
