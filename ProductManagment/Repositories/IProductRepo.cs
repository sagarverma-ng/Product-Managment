using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManagment.Models;

namespace ProductManagment.Repositories
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetProduct();
        Task<Product> GetProduct(int id);
        Task<Product> Create(Product objProduct);
        Task Update(Product objProduct);
        Task Delete(int id);
    }
}
