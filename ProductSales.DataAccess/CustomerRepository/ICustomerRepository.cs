using ProductSales.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductSales.DataAccess.CustomerRepository
{
  public interface ICustomerRepository
  {
    Task<bool> AddCustomer(Customer customer);
    Task<IEnumerable<Customer>> GetAll();
    Task<Customer> GetCustomerById(int id);
    Task<bool> UpdateById(int id, Customer customer);
    Task<bool> DeleteById(int id);

  }
}
