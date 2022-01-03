using ApplicationCore.Entities;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
    public class BasketSpecification : Specification<Basket>
    {
        public BasketSpecification(string buyerId)
        {
            Query.Where(x => x.BuyerId == buyerId);
        }
    }
}
