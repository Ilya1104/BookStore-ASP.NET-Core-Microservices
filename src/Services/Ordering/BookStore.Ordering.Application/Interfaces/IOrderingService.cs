using BookStore.Ordering.Web.Models.Ordering;

namespace BookStore.Ordering.Application.Interfaces
{
    public interface IOrderingService
    {
        Task<OrderingDto> Create(CreateOredringDto order);
        Task<OrderingDto> GetById(Guid orderId);
        Task<List<OrderingDto>> GetByCustomer(Guid customerId);
        Task<List<OrderingDto>> GetAll();
        Task Reject(Guid orderId);
    }
}
