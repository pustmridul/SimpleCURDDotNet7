using Microsoft.EntityFrameworkCore;
using SimpleCURDDotNet7.Data;
using SimpleCURDDotNet7.Interfaces;

namespace SimpleCURDDotNet7.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context =context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var obj = await _context.Products.SingleOrDefaultAsync(q=>q.Id==id);
                if(obj == null)
                {
                    return false;
                }
                else
                {
                    _context.Products.Remove(obj);
                    return true;
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            try
            {
                var obkList = await _context.Products.ToListAsync();

                return obkList.AsEnumerable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                var obj = await _context.Products.SingleOrDefaultAsync(q => q.Id == id);
                if (obj == null)
                {
                    throw new Exception();
                }
                else
                {
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SaveProduct(Product model)
        {
            try
            {
                var obj = new Product();

                obj = model;
                obj.CreateDate = DateTime.UtcNow;
                obj.CreateByName = "System";

                _context.Products.Add(obj);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateProduct(int id, Product model)
        {
            try
            {
                var obj = await _context.Products.SingleOrDefaultAsync(q => q.Id == id);
                if (obj == null)
                {
                    return false;
                }
                else
                {
                    obj.UpdateDate = DateTime.UtcNow;
                    obj.UpdateByName="System";
                    obj.ProductName = model.ProductName;
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
