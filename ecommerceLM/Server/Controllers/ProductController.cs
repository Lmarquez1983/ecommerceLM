using ecommerceLM.Server.Repositories.Interfaces;
using ecommerceLM.Shared.DTO;
using ecommerceLM.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceLM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo productRepo;
        public ProductController(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }

        //Controller to Add Product
        [HttpPost("Add-Product")]
        public async Task<ActionResult<ServiceModel>> AddProduct(Product NewProduct)
        {
            return Ok(await productRepo.AddProduct(NewProduct));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceModel>> GetAllProducts()
        {
            return Ok(await productRepo.GetAllProducts());
        }

        //Getting Product by Id
        [HttpGet("Get-Product/{ProductId:int}")]
        public async Task<ActionResult<ServiceModel>> GetProduct(int ProductId)
        {
            return Ok(await productRepo.GetProduct(ProductId));
        }

    }
}
