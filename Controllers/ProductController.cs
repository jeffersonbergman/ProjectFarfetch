using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectFarfetch.Entities;
using ProjectFarfetch.Categorie;

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
        
        public IEnumerable<Product> GetAll(int id, int? Stock = null, double? minPrice = null, double? maxPrice = null,string Categories = null)
        {
            var filter = productList;

            if (id != 0)
            {
                filter = filter.Where(p => p.Id == id).ToList();
            }

            if (Stock != null)
            {
                filter = filter.Where(p => p.Stock >= Stock).ToList();
            }

            if (minPrice != null)
            {
                filter = filter.Where(i => i.Price >= minPrice).ToList();
            }

            if (maxPrice != null)
            {
                filter = filter.Where(p => p.Price <= maxPrice).ToList();
            }

            if (!string.IsNullOrEmpty(Categories))
            {
                filter = filter.Where(p => p.categories.ToString() == Categories).ToList();
            }

            return filter;
        }

        
        [HttpPost("Create")]
        public IActionResult CreateProduct([FromBody] Product product)
        {
        
        switch (product.categories.ToString())
        {
            case "Drink":
                product.categories = Categories.Drink;
            break;
            case "Food":
                product.categories = Categories.Food;
            break;
            case "Clothing":
                product.categories = Categories.Clothing;
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

            ProductToUpdate.Name = updateproduct.Name;
            ProductToUpdate.Price = updateproduct.Price;
            ProductToUpdate.Stock = updateproduct.Stock;
            ProductToUpdate.categories = updateproduct.categories;

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