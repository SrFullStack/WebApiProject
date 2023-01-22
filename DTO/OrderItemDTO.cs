using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public int? OrdersId { get; set; }
        public int? Quantity { get; set; }
    }
}
