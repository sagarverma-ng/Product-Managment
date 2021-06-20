using ProductManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductManagment.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductContext _context;

        public ProductRepo(ProductContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _context.Products.Select(a => a).ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            //  return await _context.Products.Where(a=>a.Id =id).Select(a => a);
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> Create(Product objProduct)
        {
            _context.Products.Add(objProduct);
            await _context.SaveChangesAsync();
            return objProduct;
        }

        public async Task Update(Product objProduct)
        {
            //Product obj = _context.Products.Where(a => a.Id == objProduct.Id).Select(a => a).FirstOrDefault();
            //obj.NameData = "anything";
            //_context.SaveChanges();
            _context.Entry(objProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            //Product obj = _context.Products.Where(a => a.Id == id).Select(a => a).FirstOrDefault();
            //_context.Remove(obj);
            //_context.SaveChanges();
            var obj = await _context.Products.FindAsync(id);
            _context.Products.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
