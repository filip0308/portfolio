using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Portfolio.DataAccess;

namespace Portfolio.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController()
        {
            // Should use IoC
            this.productRepository = new ProductRepository(new MongoCollectionFactory());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            return this.Ok(await this.productRepository.GetAll());
        }
    }
}
