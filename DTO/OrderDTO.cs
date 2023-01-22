using Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? Sum { get; set; }
        public int? UserId { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
