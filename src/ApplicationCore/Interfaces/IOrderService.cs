﻿using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string buyerId, Address shippingAddress);
    }
}
