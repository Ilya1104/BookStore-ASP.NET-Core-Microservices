using BookStore.Ordering.Application.Interfaces;
using BookStore.Ordering.Application.Mappers;
using BookStore.Ordering.Domain;
using BookStore.Ordering.Domain.Entities;
using BookStore.Ordering.Web.Models.Baskets;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Ordering.Application.Services
{
    public class BasketsService(OrderingDbContext context) : IBasketService
    {
        public async Task<BasketDto> Create(BasketDto basket)
        {
            var basketEntity = new BasketEntity();           
            var basketSaveResult =  await context.Baskets.AddAsync(basketEntity);
                await context.SaveChangesAsync();

            var basketItems = basket.BasketItems
                .Select(item=>new BasketItemEntity
                {
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    BasketId = basketSaveResult.Entity.Id
                });

            await context.BasketItems.AddRangeAsync(basketItems);
            await context.SaveChangesAsync();

            var result = await context.Baskets
                .Include(x => x.BasketItems)
                .FirstAsync(x => x.Id == basketSaveResult.Entity.Id);
            return result.ToDto();

        }
    }
}
