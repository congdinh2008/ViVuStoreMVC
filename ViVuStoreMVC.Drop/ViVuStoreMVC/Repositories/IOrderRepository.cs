using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
