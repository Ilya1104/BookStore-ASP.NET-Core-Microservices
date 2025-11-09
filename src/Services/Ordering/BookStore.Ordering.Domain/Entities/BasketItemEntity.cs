namespace BookStore.Ordering.Domain.Entities
{
    public class BasketItemEntity:BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Quantity {  get; set; }
        public float Price { get; set; }

        public BasketEntity? Basket { get; set; }
        public Guid? BasketId { get; set; }
    }
}
