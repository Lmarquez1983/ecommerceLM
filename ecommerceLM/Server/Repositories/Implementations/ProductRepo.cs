using ecommerceLM.Server.Data;
using ecommerceLM.Server.Repositories.Interfaces;
using ecommerceLM.Shared.DTO;
using ecommerceLM.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerceLM.Server.Repositories.Implementations
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext appDbContext;

        public ProductRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ServiceModel> AddProduct(Product NewProduct)
        {
            var Response = new ServiceModel();
            if (NewProduct != null)
            {
                try
                {
                    appDbContext.Products.Add(NewProduct);
                    await appDbContext.SaveChangesAsync();
                    Response.SingleProduct = NewProduct;
                    Response.Success = true;
                    Response.Message = "Product added successfully!";
                    Response.CssClass = "success";
                    return Response;
                }
                catch (Exception exMessage)
                {
                    Response.CssClass = "danger";
                    Response.Message = exMessage.Message.ToString();
                    return Response;
                }
            }
            else
            {
                Response.Success = false;
                Response.Message = "Sorry New product object is empty!";
                Response.CssClass = "warning";
                Response.SingleProduct = null!;
                return Response;
            }
        }

        public async Task<ServiceModel> GetAllProducts()
        {
            var Response = new ServiceModel();
            try
            {
                var products = await appDbContext.Products.ToListAsync();
                if (products != null)
                {
                    Response.ProdList = products;
                    Response.Success = true;
                    Response.Message = "Products found!";
                    Response.CssClass = "success";
                    return Response;
                }
                else
                {
                    Response.Success = false;
                    Response.Message = "Sorry No products found!";
                    Response.CssClass = "info";
                    Response.ProdList = null!;
                    return Response;
                }

            }
            catch (Exception exMessage)
            {
                Response.CssClass = "danger";
                Response.Message = exMessage.Message.ToString();
                return Response;
            }
        }

        public async Task<ServiceModel> GetProduct(int ProductId)
        {
            var Response = new ServiceModel();
            if (ProductId > 0)
            {
                try
                {
                    var product = await appDbContext.Products.SingleOrDefaultAsync(p => p.Id == ProductId);
                    if (product != null)
                    {
                        Response.SingleProduct = product;
                        Response.Success = true;
                        Response.Message = "Product found!";
                        Response.CssClass = "success";
                        return Response;
                    }
                    else
                    {
                        Response.Success = false;
                        Response.Message = "Sorry product you are looking for doesn't exist!";
                        Response.CssClass = "info";
                        Response.SingleProduct = null!;
                        return Response;
                    }

                }
                catch (Exception exMessage)
                {
                    Response.CssClass = "danger";
                    Response.Message = exMessage.Message.ToString();
                    return Response;
                }
            }
            else
            {
                Response.Success = false;
                Response.Message = "Sorry New product object is empty!";
                Response.CssClass = "warning";
                Response.SingleProduct = null!;
                return Response;
            }
        }
    }
}
