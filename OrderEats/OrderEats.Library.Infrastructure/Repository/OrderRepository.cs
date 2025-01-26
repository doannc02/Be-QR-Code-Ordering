using Microsoft.EntityFrameworkCore;
using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Application.Mappers;
using OrderEats.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Infrastructure.Repository
{
    public class OrderRepository : IGenercRepository<Order>
        {
            private readonly OrderEatsDbContext _context;

            public OrderRepository(OrderEatsDbContext context)
            {
                _context = context;
            }

            public async Task<int> Add(Order entity)
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                // Thêm mới entity vào DbContext
                await _context.Orders.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity.Id;
            }

            public async Task<bool> Delete(int id)
            {
                var order = await _context.Orders.FindAsync(id);
                if (order == null) return false;

                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<Order> Get(int id)
            {
                return await _context.Orders
                    .Include(o => o.OrderItems)   
                    .ThenInclude(oi => oi.FoodItem) 
                    .FirstOrDefaultAsync(o => o.Id == id);
            }

            public async Task<IEnumerable<Order>> GetAll()
            {
                return await _context.Orders
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.FoodItem)
                    .ToListAsync();
            }

            public async Task<bool> Update(int id, Order entity)
            {
                if (entity == null) throw new ArgumentNullException(nameof(entity));

                var existingOrder = await _context.Orders.FindAsync(id);
                if (existingOrder == null) return false;

                existingOrder.CustomerId = entity.CustomerId;
                existingOrder.TableId = entity.TableId;
                existingOrder.OrderDate = entity.OrderDate;
                existingOrder.TotalAmount = entity.TotalAmount;
                existingOrder.Status = entity.Status;
                existingOrder.PaymentStatus = entity.PaymentStatus;
                existingOrder.OrderItems = entity.OrderItems; 

                _context.Orders.Update(existingOrder);
                await _context.SaveChangesAsync();
                return true;
            }
        }
 
}
