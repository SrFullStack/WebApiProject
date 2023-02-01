using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Repository;
using Entitiy;
using Microsoft.Extensions.Logging;

namespace Service
{
    public class OrdersService : IOrdersService
    {

        readonly ILogger<OrdersService> _Logger;
        private readonly IOrderRepository _IOrderRepository;
        private readonly IProductsRepository _IProductRepository;
        public OrdersService(IOrderRepository _IOrderRepository, IProductsRepository _IProductRepository, ILogger<OrdersService> Logger)
        {
            _Logger = Logger;
            this._IOrderRepository = _IOrderRepository;
            this._IProductRepository = _IProductRepository;
        }
        //async public Task<Order> Post(Order order)
        //{

        //    Order resorder = await _IOrderRepository.Post(order);
        //    if (resorder != null)
        //        return resorder;
        //    return null;

        //}

        public async Task AddOrder(Order order)
        {
            await _IOrderRepository.AddOrder(order);


        }
        public async Task<Order> Post(Order order)
        {
            int? sum = 0;
            foreach (var item in order.OrderItems)
            {
                Product product = await _IProductRepository.GetProductById(item.Id);

                sum = sum + product.Price;

            }
            if (sum != order.Sum)
            {
                _Logger.LogError("אתה גנב!!!!!!!!!!!!!!!!!!!!!");
            }


            order.Sum = sum;
            return await _IOrderRepository.AddOrder(order);
        }
    }
}
