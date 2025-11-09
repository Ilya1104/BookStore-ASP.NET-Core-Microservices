using BookStore.Ordering.Web.Models.Baskets;

namespace BookStore.Ordering.Web.Models.Ordering
{
    public class CreateOredringDto
    {
        public string? Name { get; set; }
        public long? OrderNumber { get; set; }
        public Guid CustomerId { get; set; }
        public BasketDto? Basket { get; set; }
    }
}
