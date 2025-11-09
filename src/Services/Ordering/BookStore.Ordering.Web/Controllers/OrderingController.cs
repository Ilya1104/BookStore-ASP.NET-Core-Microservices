
using BookStore.Ordering.Application.Controllers;
using BookStore.Ordering.Application.Interfaces;
using BookStore.Ordering.Web.Controllers;
using BookStore.Ordering.Web.Models.Ordering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BookStore.Ordering.Web.Controllers
{
    [Route("api/ordering")]
    public class OrderingController(IOrderingService orders, ILogger<OrderingController> logger) : ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateOredringDto request)
        {
            logger.LogInformation(
                $"Method api/ordering Create() started. Request: {JsonSerializer.Serialize(request)}.");
            var result = await orders.Create(request);
            logger.LogInformation(
                $"Method api/ordering Create() finished. Response: {JsonSerializer.Serialize(result)}.");
            return Ok(result);
        }

        [HttpGet("{orderId:guid}")]
        public async Task<IActionResult> GetById(Guid orderId)
        {
            logger.LogInformation($"Method api/ordering/{orderId} started.");
            var result = await orders.GetById(orderId);
            logger.LogInformation(
                $"Method api/ordering/{orderId} finished. Response: {JsonSerializer.Serialize(result)}.");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            logger.LogInformation($"Method api/ordering GetAll() started.");
            var result = await orders.GetAll();
            logger.LogInformation(
                $"Method api/ordering GetAll() finished. Result count: {result.Count}");
            return Ok(new {orders = result});
        }
        [HttpGet("customers/{customerId:guid}")]
        public async Task<IActionResult> GetByCustomer(Guid customerId)
        {
            logger.LogInformation($"Method api/ordering/customers{customerId} GetByCustomer() started.");
            var result = await orders.GetByCustomer(customerId);
            logger.LogInformation(
                $"Method api/ordering/customers{customerId} GetByCustomer() finished. Result count: {result.Count}");
            return Ok(new {orders = result});
        }

        [HttpPost("{orderId:guid}/reject")]
        public async Task<IActionResult> Reject(Guid orderId)
        {
            await orders.Reject(orderId);
            return Ok();
        }
    }
}
