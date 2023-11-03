using API.ApplicationCore.DTOs;
using API.ApplicationCore.Exceptions;
using API.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository) 
        { 
            this.productRepository = productRepository;
        }

        [HttpGet()]
        public ActionResult <List<ProductResponse>> GetProducts([FromQuery] Guid productId) 
        {
            if (productId != new Guid())
            {
                try
                {
                    var product = this.productRepository.GetProductById(productId);
                    return Ok(product);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }

            else 
            { 
                return Ok(this.productRepository.GetProducts());
            }
        }

        [HttpPost()]
        public ActionResult Create([FromBody] CreateProductRequest request)
        {
            var product = this.productRepository.CreateProduct(request);
            return Ok(product);
        }

        [HttpPut()]
        public ActionResult UpdateProduct([FromQuery] Guid pid, [FromBody] UpdateProductRequest request)
        {
            try
            {
                var product = this.productRepository.UpdateProduct(pid, request);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete()]
        public ActionResult DeleteProduct([FromQuery] Guid pid)
        {
            try
            {
                this.productRepository.DeleteProductById(pid);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
