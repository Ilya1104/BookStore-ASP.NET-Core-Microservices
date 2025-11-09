using BookStore.Ordering.Application.Interfaces;
using BookStore.Ordering.Application.Mappers;
using BookStore.Ordering.Domain;
using BookStore.Ordering.Domain.Entities;
using BookStore.Ordering.Web.Models.Ordering;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Ordering.Application.Services
{
    public class OrderingService(OrderingDbContext context, IBasketService basketsService) : IOrderingService
    {
        public async Task<OrderingDto> Create(CreateOredringDto order)
        {
            var basket = await basketsService.Create(order.Basket);
            var entity = new OrderingEntity
            {
                OrderNumber = order.OrderNumber,
                Name = order.Name,
                CustomerId = order.CustomerId,
                BasketId = basket.Id
            };

            var orderSaveResult = await context.Orders.AddAsync(entity);
            await context.SaveChangesAsync();

            var orderEntityResult = orderSaveResult.Entity;
            return orderEntityResult.ToDto();
        }

        public async Task<List<OrderingDto>> GetAll()
        {
            var entity = await context.Orders.Include(c => c.Basket)
                .ThenInclude(i => i.BasketItems)
                .ToListAsync();
            
            return entity.Select(x => x.ToDto()).ToList();
        }

        public async Task<List<OrderingDto>> GetByCustomer(Guid customerId)
        {
            var entity = await context.Orders.Include(c => c.Basket)
                .ThenInclude(i => i.BasketItems)
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
            
            return entity.Select(x => x.ToDto()).ToList();
        }

        public async Task<OrderingDto> GetById(Guid orderId)
        {
            var entity =await context.Orders.Include(c => c.Basket)
                .ThenInclude(i => i.BasketItems)
                .FirstOrDefaultAsync(x=>x.Id == orderId);
            if (entity == null)
            {
                throw new Exception($"Order with {orderId} not found");
            }
            return entity.ToDto();
        }

        public Task Reject(Guid orderId)
        {
            throw new NotImplementedException();
        }
    }
}
