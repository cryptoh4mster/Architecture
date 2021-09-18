using System;
using System.Collections.Generic;
using System.Text;
using DeliveryBLL.Interfaces;
using DeliveryBLL.DTO;
using System.Threading.Tasks;
using AutoMapper;
using DeliveryDAL.Entities;
using DeliveryDAL.Repositories;


namespace DeliveryBLL.Services
{
    /// <summary>
    /// Сервис BLL / обработка DTO / Для Create нужно преобразовать сначала OrderViewModel->DTO->Order->DTO->OrderViewModel
    /// </summary>
    public class OrderService : IOrderService
    {
        OrderRepository orderRepository;
        public OrderService(OrderRepository rep)
        {
            orderRepository = rep;
        }
        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(await orderRepository.GetAll());
        }

        public async Task<OrderDTO> Create(OrderDTO orderDTO)
        { 
            Order order = orderRepository.Create()
        }
    }
}   
