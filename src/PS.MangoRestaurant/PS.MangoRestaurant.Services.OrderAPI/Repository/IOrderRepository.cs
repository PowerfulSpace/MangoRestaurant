using PS.MangoRestaurant.Services.OrderAPI.Models;

namespace PS.MangoRestaurant.Services.OrderAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);
        Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid);
    }
}
