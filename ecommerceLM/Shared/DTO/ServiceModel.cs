using ecommerceLM.Shared.Models;

namespace ecommerceLM.Shared.DTO
{
    public class ServiceModel
    {
        public List<Product> ? ProdList { get; set; } = null;
        public Product ? SingleProduct { get; set; } = null;
        public bool Success { get; set; } = true;
        public string ? CssClass { get; set; } = "Success!";
        public string ? Message { get; set; } = null;
    }
}
