using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Text;
using System;
using Web2.API.Models;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name="IPhone X"},
            new Product {Id=2, Name="Google Pixel 8"},
            new Product {Id=3, Name="Samsung Galaxy s24"}
        };


        /// <summary>
        /// Obtient la liste de tous les produits
        /// </summary>
        /// <returns>La liste complète des Produits</returns>
        /// <response code="404">La liste est introuvable</response>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(products);
        }

        /// <summary>
        /// Crée un nouveau produit
        /// </summary>
        /// <param name="product">Le produit à créer</param>
        /// <returns>La liste des produits avec le produit nouvellement crée.</returns>
        /// <response code="201">Produit créer avec succès
        /// <para>
        /// Action réussie.L’URI de la nouvelle ressource est inclus dans
        /// l’en-tête Location de la réponse.Le corps de la réponse
        /// contient une représentation de la ressource
        /// </para>
        /// </response>
        /// <response code="200">
        /// <para>
        /// La méthode effectue des opérations de traitement, mais ne 
        /// crée pas de ressource et inclut le résultat de l’opération dans le
        /// corps de la réponse.
        /// </para>
        /// </response>
        /// <response code="204">Produit créer avec succès
        /// <para>
        /// La méthode effectue des opérations de traitement, mais ne
        /// crée pas de ressource et ne retourne pas de contenue dans le
        /// corps de la réponse
        /// </para>
        /// </response>
        /// <response code="400">Produit créer avec succès
        /// <para>
        /// données non valides dans la requête.Le corps de la réponse
        /// peut contenir des informations supplémentaires sur l’erreur ou
        /// un lien vers un URI qui fournit plus de détails
        /// </para>
        /// </response>
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

        /// <summary>
        /// Supprime un produit
        /// </summary>
        /// <param name="id">L'identifiant du produit a effacer</param>
        /// <returns>La liste des produits sans le produit nouvellement effacé</returns>
        /// <response code="200">
        /// <para>
        /// La méthode effectue des opérations de traitement, mais ne 
        /// crée pas de ressource et inclut le résultat de l’opération dans le
        /// corps de la réponse.
        /// </para>
        /// </response>
        /// <response code="404">La ressource est introuvable</response>

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
