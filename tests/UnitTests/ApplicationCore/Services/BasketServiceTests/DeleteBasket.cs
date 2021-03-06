using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Ardalis.Specification;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ApplicationCore.Services.BasketServiceTests
{
    public class DeleteBasket
    {
        private const string _buyerId = "AnExampleBuyerId";
        private readonly Mock<IRepository<Basket>> _mockBasketRepository = new ();

        [Fact]
        public async Task ShouldInvokeBasketRepositoryDeleteAsyncOnce()
        {
            Basket basket = new Basket()
            {
                Id = 1,
                BuyerId = _buyerId,
                Items = new List<BasketItem>()
                {
                    new BasketItem() { Id = 1, BasketId = 1, ProductId = 3, Quantity = 4 },
                    new BasketItem() { Id = 2, BasketId = 1, ProductId = 4, Quantity = 2 },
                }
            };

            _mockBasketRepository
                .Setup(x => x.FirstOrDefaultAsync(It.IsAny<Specification<Basket>>()))
                .ReturnsAsync(basket);

            var basketService = new BasketService(_mockBasketRepository.Object);

            await basketService.DeleteBasketAsync(_buyerId);

            _mockBasketRepository.Verify(x => x.DeleteAsync(It.IsAny<Basket>()), Times.Once);
        }
    }
}
