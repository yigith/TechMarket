using ApplicationCore.Entities;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<Order> CreateOrderAsync(Address address);

        Task<BasketViewModel> GetBasketAsync();

        Task<BasketViewModel> AddBasketItemAsync(int productId, int quantity = 1);

        Task<int> BasketItemsCountAsync();

        Task EmptyBasketAsync();

        Task RemoveBasketItemAsync(int basketItemId);

        Task UpdateBasketItemsAsync(int[] basketItemIds, int[] quantities);
    }
}
