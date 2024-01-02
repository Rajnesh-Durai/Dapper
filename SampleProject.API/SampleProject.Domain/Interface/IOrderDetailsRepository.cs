namespace SampleProject.Domain.Interface
{
    public interface IOrderDetailsRepository<T>
    {
        Task<List<T>> GetAllOrderDetails();
        Task<T> GetByIdOrderDetails(int Id);
        Task<string> AddOrderItems(T order);
        Task<string> UpdateOrderItems(T order);
        Task<string> DeleteOrderItems(int id);
    }
}
