using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SampleProject.Application.Features.OrderDetail.Command;
using SampleProject.Application.ViewModels;
using SampleProject.Domain.Interface;
using SampleProject.Domain.Models;
using SampleProject.Domain.Service;

namespace SampleProject.Application.Features.OrderDetail.Handler
{
    public class CheckoutOrderItemsHandler : IRequestHandler<CheckoutOrderItemsCommand, string>
    {
        private readonly IOrderDetailsRepository<OrderItems> repository;
        private readonly IMapper mapper;
        private readonly ILogger<CheckoutOrderItemsHandler> logger;
        private readonly IServiceBusSender<OrderItemsResponse> serviceBusSender;
        public CheckoutOrderItemsHandler(IOrderDetailsRepository<OrderItems> repository, IMapper mapper, ILogger<CheckoutOrderItemsHandler> logger, IServiceBusSender<OrderItemsResponse> serviceBusSender)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
            this.serviceBusSender = serviceBusSender;
        }

        public async Task<string> Handle(CheckoutOrderItemsCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = this.mapper.Map<OrderItems>(request);
            var result = await this.repository.AddOrderItems(orderEntity);
            this.logger.LogInformation(($"OrderItem {result} successfully created."));
            await this.serviceBusSender.SendCommandQueue(result);
            return result;
        }
    }
}
