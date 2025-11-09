namespace BookStore.Ordering.Domain.Entities
{
    public class OrderingEntity:BaseEntity
    {
        public string? Name { get; set; }
        public long? OrderNumber { get; set; }


        public CustomerEntity? Customer { get; set; }
        public Guid? CustomerId { get; set; }


        public BasketEntity? Basket { get; set; }
        public Guid? BasketId { get; set; }
    }
}
