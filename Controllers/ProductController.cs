using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectFarfetch.Entities;

namespace ProjectFarfetch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
       
        private static List<Product> productList = new List<Product>();
        



        [HttpGet("Search/All")]
        public IEnumerable<Product> Get()
        {
            return productList;
        }
        
        
        [HttpGet("Search/Filter")]
        
        public IEnumerable<Product> GetAll(int id, int? stock = null, double? minPrice = null, double? maxPrice = null,string Categorys = null)
        {
            var filter = productList;

            if (id != 0)
            {
                filter = filter.Where(p => p.Id == id).ToList();
            }

            if (stock != null)
            {
                filter = filter.Where(p => p.stock >= stock).ToList();
            }

            if (minPrice != null)
            {
                filter = filter.Where(i => i.price >= minPrice).ToList();
            }

            if (maxPrice != null)
            {
                filter = filter.Where(p => p.price <= maxPrice).ToList();
            }

            if (!string.IsNullOrEmpty(Categorys))
            {
                filter = filter.Where(p => p.categorys.ToString() == Categorys).ToList();
            }

            return filter;
        }

        
        [HttpPost("Create")]
        public IActionResult CreateProduct([FromBody] Product product)
        {
        
        switch (product.categorys.ToString())
        {
            case "Drink":
                product.categorys = Category.Drink;
            break;
            case "Food":
                product.categorys = Category.Food;
            break;
            case "Clothing":
                product.categorys = Category.Clothing;
            break;
            
            default:
            return BadRequest();
        }
            
            productList.Add(product);
            return Ok(product);
        }
            


        [HttpPut("Update/{id}")]

        public IActionResult Updatedproduct(int id, [FromBody] Product updateproduct)
        {
            var ProductToUpdate = productList.FirstOrDefault(p => p.Id == id);

            if(ProductToUpdate == null)
            {
                return NotFound();
            }

            ProductToUpdate.name = updateproduct.name;
            ProductToUpdate.price = updateproduct.price;
            ProductToUpdate.stock = updateproduct.stock;
            ProductToUpdate.categorys = updateproduct.categorys;

            return NoContent();

        }




        [HttpDelete("Delete/{id}")]

        public IActionResult DeletedProduct(int id)
        {
            var ProductToDelete = productList.FirstOrDefault(p => p.Id == id);

            if (ProductToDelete == null)
            {
                return NotFound();
            }

            productList.Remove(ProductToDelete);

            return NoContent();
        }

        
    }
        
}