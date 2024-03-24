using myfirstWebApp.Models;

namespace myfirstWebApp.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}