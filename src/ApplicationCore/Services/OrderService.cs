using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Basket> _basketRepository;
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Basket> basketRepository, IRepository<Order> orderRepository)
        {
            _basketRepository = basketRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrderAsync(string buyerId, Address shippingAddress)
        {
            var specBasket = new BasketWithItemsSpecification(buyerId);
            var basket = await _basketRepository.FirstOrDefaultAsync(specBasket);

            Order order = new Order()
            {
                BuyerId = buyerId,
                ShipToAddress = shippingAddress,
                Items = basket.Items.Select(x => new OrderItem()
                {
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    ProductPictureUri = x.Product.PictureUri,
                    ProductPrice = x.Product.Price,
                    Quantity = x.Quantity
                }).ToList()
            };

            return await _orderRepository.AddAsync(order);
        }
    }
}
