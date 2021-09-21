using System;
using System.Collections.Generic;
using System.Text;
using DeliveryBLL.Interfaces;
using DeliveryBLL.DTO;
using System.Threading.Tasks;
using AutoMapper;
using DeliveryDAL.Entities;
using DeliveryDAL.Repositories;
using DeliveryDAL.Interfaces;


namespace DeliveryBLL.Services
{
    /// <summary>
    /// Сервис BLL / обработка DTO / Для Create нужно преобразовать сначала OrderViewModel->DTO->Order->DTO->OrderViewModel
    /// </summary>
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository rep, IMapper map)
        {
            _orderRepository = rep;
            _mapper = map;
        }
        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<OrderDTO>>(await _orderRepository.GetAll());
        }

        public async Task<OrderDTO> CreateOrder(OrderDTO orderDTO)
        {
            var mappedOrderFromPL = _mapper.Map<Order>(orderDTO);
            Order order = await _orderRepository.CreateOrder(mappedOrderFromPL);
            var mapperOrderFromDAL = _mapper.Map<OrderDTO>(order);
            return mapperOrderFromDAL;
        }
    }
}   
