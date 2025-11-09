namespace BookStore.Ordering.Domain.Entities
{
    public class CustomerEntity:BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public List<OrderingEntity>? Orders { get; set; }

    }
}
