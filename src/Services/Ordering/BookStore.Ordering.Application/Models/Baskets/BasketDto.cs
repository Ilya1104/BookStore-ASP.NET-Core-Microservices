using BookStore.Ordering.Domain.Entities;

namespace BookStore.Ordering.Web.Models.Baskets
{
    public class BasketDto
    {
        public Guid? Id { get; set; }
        public List<BasketItemDto> BasketItems { get; set; } = null!;
    }
}
