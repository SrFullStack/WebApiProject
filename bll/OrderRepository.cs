using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitiy;


namespace T_Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly UserContext _dbContext;
        public OrderRepository(UserContext dbContext)
        {
            _dbContext = dbContext;


        }
   
 
        public async Task <Order>AddOrder(Order order)

        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;

        }

    }
}
