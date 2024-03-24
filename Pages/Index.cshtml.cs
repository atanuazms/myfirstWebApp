using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myfirstWebApp.Models;
using myfirstWebApp.Services;

namespace myfirstWebApp.Pages
{
    public class IndexModel : PageModel
    {

        public List<Product> Products;

        public void OnGet()
        {
            ProductService productService = new ProductService();
            Products = productService.GetProducts();
        }
    }
}