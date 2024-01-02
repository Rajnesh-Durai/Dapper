using Dapper;
using SampleProject.Domain.Models;
using SampleProject.Infrastructure.Data;
using System.Data;

namespace SampleProject.Infrastructure.DataAccess
{
    public class OrderDetailsDataAccess
    {
        public readonly DapperContext context;
        public OrderDetailsDataAccess(DapperContext context)
        {
            this.context = context;
        }
        public async Task<List<OrderItems>> GetAllAsync()
        {
            var query = "[usp.GetAllOrderItems]";
            using (var connection = this.context.CreateConnection())
            {
                var result = await connection.QueryAsync<OrderItems>(query, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public async Task<OrderItems> GetByIdAsync(int Id)
        {
            var query = "[usp.GetByIdOrderItems]";
            using (var connection = this.context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<OrderItems>(query, new { Id }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<string> AddAsync(OrderItems items)
        {
            string result = string.Empty;
            var query = "[usp.AddOrderItems]";
            var parameter = new DynamicParameters();
            parameter.Add("@CustomerOrderId", items.CustomerOrderId);
            parameter.Add("@UnitPrice", items.UnitPrice);
            parameter.Add("@Quantity", items.Quantity);
            using (var connection = this.context.CreateConnection())
            {
                var output = await connection.ExecuteAsync(query, parameter, commandType: CommandType.StoredProcedure);
                result = "Added Successfully";
            }
            return result;
        }
        public async Task<string> UpdateAsync(OrderItems items)
        {
            string result = string.Empty;
            var query = "[usp.UpdateOrderItems]";
            var parameter = new DynamicParameters();
            parameter.Add("@Id", items.Id);
            parameter.Add("@CustomerOrderId", items.CustomerOrderId);
            parameter.Add("@UnitPrice", items.UnitPrice);
            parameter.Add("@Quantity", items.Quantity);
            using (var connection = this.context.CreateConnection())
            {
                var output = await connection.ExecuteAsync(query, parameter, commandType: CommandType.StoredProcedure);
                result = "Updated Successfully";
            }
            return result;
        }
        public async Task<string> DeleteAsync(int Id)
        {
            string result = string.Empty;
            var query = "[usp.DeleteOrderItems]";
            using (var connection = this.context.CreateConnection())
            {
                var output = await connection.ExecuteAsync(query, new { Id }, commandType: CommandType.StoredProcedure);
                result = "Deleted Successfully";
            }
            return result;
        }
    }
}
