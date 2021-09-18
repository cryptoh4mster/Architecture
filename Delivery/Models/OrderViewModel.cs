using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryBLL.DTO;

namespace DeliveryPL.Models
{
    public class OrderViewModel
    {
        public OrderViewModel(OrderDTO orderDTO)
        {
                
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
