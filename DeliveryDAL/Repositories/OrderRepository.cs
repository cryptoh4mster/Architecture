using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeliveryDAL.Entities;
using DeliveryDAL.EF;
using Microsoft.EntityFrameworkCore;
using DeliveryDAL.Interfaces;

namespace DeliveryDAL.Repositories
{
    /// <summary>
    /// ЛОгика Data Access Layer 
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly DeliveryContext db;
        public OrderRepository(DeliveryContext context)
        {
            db = context;
        }
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await db.Orders.ToListAsync();
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            return order;
        }
    }
}
    