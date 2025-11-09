using BookStore.Ordering.Domain.Entities;
using BookStore.Ordering.Web.Models.Baskets;

namespace BookStore.Ordering.Application.Mappers;

public static class BasketsMapper
{
    public static BasketDto ToDto(this BasketEntity entity)
    {
        return new BasketDto
        {
            Id = entity.Id,
            BasketItems = entity.BasketItems!.Select(item => new BasketItemDto
            {
                Id = item.Id,
                Price = item.Price,
                Quantity = item.Quantity,
                Name = item.Name
            }).ToList()
        };
    }
    public static BasketEntity ToEntity(this BasketDto dto)
    {
        return new BasketEntity
        {
           BasketItems = dto.BasketItems.Select(basket => basket.ToEntity()).ToList()
        };
    }

    public static BasketItemEntity ToEntity(this BasketItemDto dto)
    {
        return new BasketItemEntity
        {
            Name = dto.Name,
            Price = dto.Price,
            Quantity = dto.Quantity
        };
    }
}