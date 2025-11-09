namespace BookStore.Ordering.Web.Models.Baskets
{
    public class BasketItemDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
