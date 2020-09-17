using System.Threading.Tasks;
using System.Collections.Generic;
using ProductSales.Models;

namespace ProductSales.DataAccess.InvoiceRepository
{
  public interface IInvoiceRepository
  {
    Task<IEnumerable<Invoice>> GetAll();
    Task<bool> GenerateInvoice(int customerId);
    Task<bool> GenerateInvoiceForAll();
  }
}
