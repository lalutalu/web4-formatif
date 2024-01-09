using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web2.API.Models;

namespace Web2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name="IPhone X"},
            new Product {Id=2, Name="Google Pixel 8"},
            new Product {Id=3, Name="Samsung Galaxy s24"}
        };


        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(products);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Erreurs lors de la création du produit. Données invalide");
            }

            int nouveauId = products.Max(x => x.Id) + 1;
            product.Id = nouveauId;
            products.Add(product);

            return Ok(products);

        }

        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return BadRequest("Erreurs lors de la création du produit. Données invalide");
            }

            products.Remove(product);
            return Ok(products);
        }
    }
}
