using DealerOn.Web.Models;

using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DealerOn.Controllers
{
    public class ProductsController : Controller
    {       
        private readonly DealerOnContext _context;

        public ProductsController(DealerOnContext context)
        {            
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();            
            
            return View(products);
        }
    }
}
