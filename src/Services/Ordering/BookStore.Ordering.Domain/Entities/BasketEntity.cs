namespace BookStore.Ordering.Domain.Entities
{
    public class BasketEntity:BaseEntity
    {
        public List<BasketItemEntity>? BasketItems { get; set; }
    }
}
