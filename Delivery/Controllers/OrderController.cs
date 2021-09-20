using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryBLL.Interfaces;
using DeliveryPL.Models;
using AutoMapper;
using DeliveryBLL.DTO;

namespace DeliveryPL.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        
        public OrderController(IOrderService serv, IMapper mapper)
        {
            _orderService = serv;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetAll()
        {
            var list = await _orderService.GetAll();
            var testMap = _mapper.Map<IEnumerable<OrderViewModel>>(list);
            return View("Orders", testMap);
        }
        public async Task<ActionResult<OrderViewModel>> CreateOrder(OrderViewModel orderViewModel)
        {
            var mappedDTOFromVM = _mapper.Map<OrderDTO>(orderViewModel);
            var orderDTO = await _orderService.CreateOrder(mappedDTOFromVM);
            var mappedOrderVMFromDTO = _mapper.Map<OrderViewModel>(orderDTO);
            return RedirectToAction("GetAll");
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Orders()
        {
            return RedirectToAction("GetAll");
        }

        public IActionResult Ordering()
        {
            return View("Ordering");
        }
    }
}
