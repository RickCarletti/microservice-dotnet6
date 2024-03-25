using GeekShooping.ProductAPI.Data.ValueObjects;
using GeekShooping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.ProductAPI.Controllers
{
    [Route("api/v1/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository repository)
        {
            _productRepository = repository ?? throw new ArgumentException(nameof(repository));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _productRepository.FindAll();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create(ProductVO product)
        {
            if (product == null) { return BadRequest(); }

            product = await _productRepository.Create(product);

            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update(ProductVO product)
        {
            if (product == null) { return BadRequest(); }

            await _productRepository.Update(product);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var excluido = await _productRepository.Delete(id);
            if (!excluido) return BadRequest();
            return Ok(excluido);
        }
    }
}
