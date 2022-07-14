using DealerOn.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerOn.Models
{
    public class Cart : ICart
    {
        private ITaxCalculator _taxService;

        public List<Product> Products { get; set; }
        public decimal TotalSalesTax { get; set; }
        public decimal TotalPrice { get; set; }


        public Cart()
        {
            _taxService = new TaxCalculator();
            Products = new List<Product>();
        }
        
        public void Add(Product product)
        {

            
            var salesTax = _taxService.Calculate(product);
            TotalSalesTax += salesTax;
            product.TotalPrice = salesTax + product.Price;
            if(Products.Any(p => p.Name == product.Name))
            {
                Products.Where(p => p.Name == product.Name).ToList().ForEach(p => p.Quantity += product.Quantity);
            }
            else
            {
                Products.Add(product);
            }
          
            
        }

        public string Purchase()
        {
            var stringBuilder = new StringBuilder();
            foreach (var purchase in Products)
            {
                if(purchase.Quantity > 1)
                {
                    stringBuilder.AppendLine($"{purchase.Name}: {purchase.TotalPrice * purchase.Quantity} ({purchase.Quantity} @ {purchase.TotalPrice:f2})");
                }
                else
                {
                    stringBuilder.AppendLine($"{purchase.Name}: {purchase.TotalPrice:f2}");
                }
                
            }

            return stringBuilder.ToString();
        }


    }
}
