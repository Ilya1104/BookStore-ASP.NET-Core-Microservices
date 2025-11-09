namespace BookStore.Ordering.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
