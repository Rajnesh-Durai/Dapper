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
    public class DeleteOrderItemsHandler : IRequestHandler<DeleteOrderItemsCommand, string>
    {
        private readonly IOrderDetailsRepository<OrderItems> repository;
        private readonly IMapper mapper;
        private readonly ILogger<CheckoutOrderItemsHandler> logger;
        private readonly IServiceBusSender<OrderItemsResponse> serviceBusSender;
        public DeleteOrderItemsHandler(IOrderDetailsRepository<OrderItems> repository, IMapper mapper, ILogger<CheckoutOrderItemsHandler> logger, IServiceBusSender<OrderItemsResponse> serviceBusSender)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
            this.serviceBusSender = serviceBusSender;
        }
        public async Task<string> Handle(DeleteOrderItemsCommand request, CancellationToken cancellationToken)
        {
            var result = await this.repository.DeleteOrderItems(request.Id);
            this.logger.LogInformation(($"OrderItem {result} successfully deleted."));
            await this.serviceBusSender.SendCommandQueue(result);
            return result;
        }
    }
}
