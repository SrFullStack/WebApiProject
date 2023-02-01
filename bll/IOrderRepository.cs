using Entitiy;

namespace T_Repository
{
    public interface IOrderRepository
    {
        //Task<Order> Post(Order order);
        Task<Order> AddOrder(Order order);
    }
}