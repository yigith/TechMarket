using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
    public class HomeViewModelService
    {
        private readonly IRepository<Product> _productRepository;

        public HomeViewModelService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
