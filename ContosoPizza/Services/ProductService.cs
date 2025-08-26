using ContosoPizza.Data;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public class ProductService
    {
        private readonly PizzaContext _context = default!;

        public ProductService(PizzaContext context) 
        {
            _context = context;
        }
        
        public IList<Pizza> GetProducts()
        {
            if(_context.Pizzas != null)
            {
                return _context.Pizzas.ToList();
            }
            return new List<Pizza>();
        }

        public void AddProduct(Pizza product)
        {
            if (_context.Pizzas != null)
            {
                _context.Pizzas.Add(product);
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            if (_context.Pizzas != null)
            {
                var product = _context.Pizzas.Find(id);
                if (product != null)
                {
                    _context.Pizzas.Remove(product);
                    _context.SaveChanges();
                }
            }            
        } 
    }
}
