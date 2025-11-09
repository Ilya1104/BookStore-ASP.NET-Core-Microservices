using BookStore.Ordering.Domain.Entities;

using BookStore.Ordering.Web.Models.Baskets;
using BookStore.Ordering.Web.Models.Ordering;

namespace BookStore.Ordering.Application.Mappers;

public static class OrdersMapper
{
    public static OrderingDto ToDto(this OrderingEntity entity, BasketEntity? basket=null)
    {
        return new OrderingDto
        {
            Id = entity.Id,
            CustomerId = entity.CustomerId!.Value,
            Basket = basket==null?entity?.Basket.ToDto():basket?.ToDto(),
            Name = entity.Name,
            OrderNumber = entity.OrderNumber
        };
    }

    public static OrderingEntity ToEntity(this CreateOredringDto entity, BasketDto? basket = null)
    {
        return new OrderingEntity
        {
            CustomerId = entity.CustomerId,
            Basket = basket?.ToEntity(),
            Name = entity.Name,
            OrderNumber = entity.OrderNumber
        };
    }
}