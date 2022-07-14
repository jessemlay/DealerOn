using DealerOn.Models;

namespace DealerOn.Services.Interfaces
{
    public interface ICart
    {
        public void Add(Product product);     
        public string Purchase();
    }
}
