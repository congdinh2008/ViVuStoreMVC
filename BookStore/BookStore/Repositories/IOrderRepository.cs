using BookStore.Models;

namespace BookStore.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
