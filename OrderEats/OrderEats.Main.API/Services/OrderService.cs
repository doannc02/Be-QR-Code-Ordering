using Microsoft.AspNetCore.SignalR;
using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Application.Mappers;
using OrderEats.Library.Models.DTO;
using OrderEats.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenercRepository<Order> _orderRepository;
        private readonly OrderMapper _orderMapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHubContext<OrderHub> _hubContext;  

        public OrderService(IGenercRepository<Order> orderRepository,
                            OrderMapper orderMapper,
                            IHttpContextAccessor httpContextAccessor,
                            IHubContext<OrderHub> hubContext)
        {
            _orderRepository = orderRepository;
            _orderMapper = orderMapper;
            _httpContextAccessor = httpContextAccessor;
            _hubContext = hubContext;
        }

        public async Task<OrderDTO> CreateOrderAsync(OrderDTO orderDto)
        {
            if (orderDto == null)
            {
                throw new ArgumentNullException(nameof(orderDto), "OrderDTO không thể là null");
            }

            //var userId = _httpContextAccessor.HttpContext.User?.FindFirst("UserId")?.Value;
            var order = _orderMapper.MapV2(orderDto);
            var orderId = await _orderRepository.Add(order);
            if (orderId == null)
            {
                return null;
            }
            var orderDetail = await _orderRepository.Get(orderId);
            var orderDetailDTO  = _orderMapper.Map(orderDetail);
            await _hubContext.Clients.All.SendAsync( "Khách hàng đã đặt đơn hàng mới!", orderDetailDTO);
            return orderDetailDTO;
        }

        public async Task RespondToUserAsync(string connectionId, string responseMessage)
        {
            // Gửi thông báo phản hồi tới đúng user qua connectionId
            await _hubContext.Clients.Client(connectionId).SendAsync("ReceiveMessage", responseMessage);
        }

        public async Task NotifyAdminAsync(string message)
        {
            // Gửi thông báo cho Admin
            await _hubContext.Clients.All.SendAsync("OrderMessage", message);
        }

        public async Task<OrderDTO> GetOrderAsync(int orderId)
        {
            var order = await _orderRepository.Get(orderId);
            return _orderMapper.Map(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAll();
            return orders.Select(order => _orderMapper.Map(order));
        }

        public async Task<bool> UpdateOrderAsync(int orderId, OrderDTO orderDto)
        {
            var order = _orderMapper.Map(orderDto);
            if (order == null) return false;
            return await _orderRepository.Update(orderId, order);
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            return await _orderRepository.Delete(orderId);
        }
    }
}
