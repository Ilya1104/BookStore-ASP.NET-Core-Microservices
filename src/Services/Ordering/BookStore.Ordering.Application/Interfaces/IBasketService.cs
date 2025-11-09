using BookStore.Ordering.Web.Models.Baskets;

namespace BookStore.Ordering.Application.Interfaces
{
    public interface IBasketService
    {
        Task<BasketDto> Create(BasketDto basket);
    }
}
