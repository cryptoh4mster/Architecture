using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryBLL.Interfaces;
using DeliveryPL.Models;

namespace DeliveryPL.Controllers
{
    public class OrderController : Controller
    {
        IOrderService orderService;
        
        public OrderController(IOrderService serv)
        {
            orderService = serv;
        }

        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetAll()
        {
            var list = await orderService.GetAll();
            return View(list);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
