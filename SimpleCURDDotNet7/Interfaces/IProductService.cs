using SimpleCURDDotNet7.Data;

namespace SimpleCURDDotNet7.Interfaces
{
    public interface IProductService
    {
        Task<bool> SaveProduct(Product model);
        Task<bool> UpdateProduct(int id,Product model);
        Task<bool> DeleteProduct(int id);
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetAllProduct();
    }
}