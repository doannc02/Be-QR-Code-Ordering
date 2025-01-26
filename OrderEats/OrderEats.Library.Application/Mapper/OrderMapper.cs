using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Models.Entities;
using OrderEats.Library.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using OrderEats.Library.Application.Mapper;
using Mysqlx.Crud;
using Order = OrderEats.Library.Models.Entities.Order;

namespace OrderEats.Library.Application.Mappers
{
    public class OrderMapper : IMapper<Order, OrderDTO>
    {
        public OrderDTO Map(Order source)
        {
            if (source == null) return null;

            var orderDto = new OrderDTO
            {
               Id = source.Id,
                CustomerId = source.CustomerId,
                TableId = source.Table?.Id ?? 0,
                OrderDate = source.OrderDate,
                TotalAmount = source.TotalAmount,
                Status = source.Status.ToString(),
                PaymentStatus = source.PaymentStatus.ToString(),
                OrderItems = source.OrderItems?.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    Notes = oi.Notes,
                    FoodItemId = oi.FoodItemId,
                    Price = oi.Price,
                    Quantity = oi.Quantity
                }).ToList() ?? new List<OrderItemDto>()
            };

            return orderDto;
        }

        public Order Map(OrderDTO destination)
        {
            //if(destination.OrderId == null)
            //{
            //    return null;
            //}
            if (destination == null) return null;

            var status = Enum.TryParse<OrderStatus>(destination.Status, out var parsedStatus)
                ? parsedStatus
                : OrderStatus.Pending;
            var paymentStatus = Enum.TryParse<PaymentStatus>(destination.PaymentStatus, out var parsedPaymentStatus)
                ? parsedPaymentStatus
                : PaymentStatus.Unpaid;

            var order = new Order
            {
                Id = (int)destination.Id,
                CustomerId = destination.CustomerId,
                CustomerName = destination.CustomerName,
                OrderDate = destination.OrderDate,
                TotalAmount = destination.TotalAmount,
                Status = status,
                PaymentStatus = paymentStatus,
                TableId = destination.TableId,
                OrderItems = destination.OrderItems?.Select(oi => new OrderItem
                {
                    Id = (int)oi.Id,
                    FoodItemId = oi.FoodItemId,
                    Notes = oi.Notes,
                    Price = oi.Price,
                    Quantity = oi.Quantity
                }).ToList() ?? new List<OrderItem>()
            };

            return order;
        }

        public Order MapV2(OrderDTO destination)
        {
            if (destination == null) return null;

            var status = Enum.TryParse<OrderStatus>(destination.Status, out var parsedStatus)
                ? parsedStatus
                : OrderStatus.Pending;
            var paymentStatus = Enum.TryParse<PaymentStatus>(destination.PaymentStatus, out var parsedPaymentStatus)
                ? parsedPaymentStatus
                : PaymentStatus.Unpaid;

            var order = new Order
            {
                CustomerId = destination.CustomerId,
                CustomerName = destination.CustomerName,
                OrderDate = destination.OrderDate,
                TotalAmount = destination.TotalAmount,
                Status = status,
                PaymentStatus = paymentStatus,
                TableId = destination.TableId,
                OrderItems = destination.OrderItems?.Select(oi => new OrderItem
                {
                    FoodItemId = oi.FoodItemId,
                    Notes = oi.Notes,
                    Price = oi.Price,
                    Quantity = oi.Quantity
                }).ToList() ?? new List<OrderItem>()
            };

            return order;
        }

        public List<OrderDTO> MapList(IEnumerable<Order> source)
        {
            if (source == null) return null;

            return source.Select(Map).ToList();
        }
    }

}
