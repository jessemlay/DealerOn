namespace DealerOn.Models
{
    public class Category
    {
        public enum Categories
        {
            Books = 0,
            Food = 1,
            Medical = 2,
            Other = 3,
        }

        public int CategoryId { get; set; }
        public Categories Name { get; set; }
        public bool SalesTax { get; set; }
    }
}
