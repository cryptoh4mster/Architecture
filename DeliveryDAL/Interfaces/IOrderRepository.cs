using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeliveryDAL.Entities;

namespace DeliveryDAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> CreateOrder(Order item);

    }
}
