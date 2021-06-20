using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagment.Models;
using ProductManagment.Repositories;


namespace ProductManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;

        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _repo.GetProduct();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProduct(id);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProducts([FromBody] Product objProduct)
        {
            var newProduct = await _repo.Create(objProduct);
            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] Product objProduct)
        {
            if (id != objProduct.Id)
            {
                return BadRequest();
            }
            await _repo.Update(objProduct);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _repo.GetProduct(id);
            if (res == null)
            {
                return NoContent();
            }
            await _repo.Delete(id);
            return NoContent();
        }

    }
}
