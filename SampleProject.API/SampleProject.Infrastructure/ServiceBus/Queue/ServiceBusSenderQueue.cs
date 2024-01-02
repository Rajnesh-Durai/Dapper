using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SampleProject.Application.ViewModels;
using System.Text;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using SampleProject.Domain.Service;

namespace SampleProject.Infrastructure.ServiceBus.Queue
{
    public class ServiceBusSenderQueue:IServiceBusSender<OrderItemsResponse>
    {
        public readonly IConfiguration configuration;
        public readonly ILogger<ServiceBusSenderQueue> logger;

        public ServiceBusSenderQueue(IConfiguration configuration, ILogger<ServiceBusSenderQueue> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }
        public async Task SendQueryQueue(OrderItemsResponse message)
        {
            var connectionString = this.configuration["ServiceBus:ConnectionString"];
            var queueName = this.configuration["ServiceBus:QueueName"];
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(queueName);
            try
            {
                var jsonConvert = JsonConvert.SerializeObject(message);
                var serviceBusMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonConvert));
                await sender.SendMessageAsync(serviceBusMessage);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error sending message to Service Bus: {ex.Message}");
            }
            finally
            {
                await sender.CloseAsync();
            }
        }
        public async Task SendQueryListQueue(List<OrderItemsResponse> message)
        {
            var connectionString = this.configuration["ServiceBus:ConnectionString"];
            var queueName = this.configuration["ServiceBus:QueueName"];
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(queueName);
            try
            {
                var jsonConvert = JsonConvert.SerializeObject(message);
                var serviceBusMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonConvert));
                await sender.SendMessageAsync(serviceBusMessage);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error sending message to Service Bus: {ex.Message}");
            }
            finally
            {
                await sender.CloseAsync();
            }
        }
        public async Task SendCommandQueue(string message)
        {
            var connectionString = this.configuration["ServiceBus:ConnectionString"];
            var queueName = this.configuration["ServiceBus:QueueName"];
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(queueName);
            try
            {
                var serviceBusMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(message));
                await sender.SendMessageAsync(serviceBusMessage);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error sending message to Service Bus: {ex.Message}");
            }
            finally
            {
                await sender.CloseAsync();
            }
        }
    }
}
