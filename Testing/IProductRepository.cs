using System;
using System.Collections.Generic;
using System.Linq;
using Testing.Models;

namespace Testing
{
    interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
    }
}
