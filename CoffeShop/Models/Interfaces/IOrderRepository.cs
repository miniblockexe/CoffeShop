namespace CoffeShop.Models.Interfaces
{
    public interface IOrderRepository
    {
        void PlaceOrder(Order order);
        IEnumerable<Order> GetOrdersByUserId(string userId);
        IEnumerable<Order> GetAllOrders();
    }
}
