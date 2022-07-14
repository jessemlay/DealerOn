namespace DealerOn.Web.Models
{
    public class Product
    {       
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get ; set ; }        
        public int Quantity { get; set; }        
        public bool Imported { get ; set ; }        
        public string Image { get ; set ; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }        
    }
}

