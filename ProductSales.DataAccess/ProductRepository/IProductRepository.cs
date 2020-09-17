using ProductSales.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ProductSales.DataAccess.ProductRepository
{
  public interface IProductRepository
  {
    Task<bool> AddProduct(Product product);
    Task<bool> DeleteById(int id);
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetProductById(int id);
    Task<bool> UpdateById(int id, Product product);
  }
}
