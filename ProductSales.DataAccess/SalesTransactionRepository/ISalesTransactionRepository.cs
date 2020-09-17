using ProductSales.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductSales.DataAccess.SalesTransactionRepository
{
  public interface ISalesTransactionRepository
  {
    Task<bool> AddSalesTransaction(SalesTransaction salesTransaction);
    Task<IEnumerable<SalesTransaction>> GetAll();

  }
}
