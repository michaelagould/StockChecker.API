using System.Threading.Tasks;

namespace StockChecker.UWP.Helpers
{
    public interface IHttpStockClientHelper
    {
        Task<int> GetQuantityAsync(int productId);
        Task UpdateQuantityAsync(int productId, int newQuantity);
        Task<bool> Login(string username, string password);
    }
}