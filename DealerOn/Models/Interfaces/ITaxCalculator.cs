using DealerOn.Models;

namespace DealerOn.Services.Interfaces
{
    public interface ITaxCalculator
    {
        decimal Calculate(Product product);
    }
}
