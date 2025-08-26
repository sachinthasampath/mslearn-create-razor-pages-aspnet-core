using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Pages
{
    public class ProductListModel : PageModel
    {
        private readonly ProductService _service;
        public IList<Pizza> ProductList { get; set; } = default!;
        public IList<Pizza> PizzasList { get; set; } = default!;

        [BindProperty]
        public Pizza NewProduct { get; set; } = default!;

        public ProductListModel(ProductService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            ProductList = _service.GetProducts();
            PizzasList = _service.GetProducts();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewProduct == null)
            {
                return Page();
            }

            _service.AddProduct(NewProduct);

            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            _service.DeleteProduct(id);

            return RedirectToAction("Get");
        }
    }
}
