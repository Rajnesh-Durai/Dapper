using Microsoft.Extensions.Logging;
using SampleProject.Domain.Interface;
using SampleProject.Domain.Models;
using SampleProject.Infrastructure.DataAccess;

namespace SampleProject.Infrastructure.Repositories
{
    public class OrderItemsRepository : IOrderDetailsRepository<OrderItems>
    {
        public readonly ILogger<OrderItemsRepository> logger;
        public readonly OrderDetailsDataAccess dataAccess;
        public OrderItemsRepository(ILogger<OrderItemsRepository> logger, OrderDetailsDataAccess dataAccess)
        {
            this.logger = logger;
            this.dataAccess = dataAccess;
        }
        public async Task<List<OrderItems>> GetAllOrderDetails()
        {
            this.logger.LogInformation("Fetching the List of Order from Database");
            return await this.dataAccess.GetAllAsync();
        }
        public async Task<OrderItems> GetByIdOrderDetails(int Id)
        {
            this.logger.LogInformation("Fetching the Particular Order from Database");
            return await this.dataAccess.GetByIdAsync(Id);
        }
        public async Task<string> AddOrderItems(OrderItems items)
        {
            this.logger.LogInformation("Inserting the Particular Order to Database");
            return await this.dataAccess.AddAsync(items);
        }
        public async Task<string> UpdateOrderItems(OrderItems items)
        {
            this.logger.LogInformation("Updating the Particular Order to Database");
            return await this.dataAccess.UpdateAsync(items);
        }
        public async Task<string> DeleteOrderItems(int Id)
        {
            this.logger.LogInformation("Deleting the Particular Order to Database");
            return await this.dataAccess.DeleteAsync(Id);
        }
    }
}
