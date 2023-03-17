using ecommerceLM.Shared.DTO;
using ecommerceLM.Shared.Models;

namespace ecommerceLM.Server.Repositories.Interfaces
{
    public interface IProductRepo
    {
        public Task<ServiceModel> AddProduct(Product NewProduct);
        public Task<ServiceModel> GetAllProducts();
        public Task<ServiceModel> GetProduct(int ProductId);
    }
}
