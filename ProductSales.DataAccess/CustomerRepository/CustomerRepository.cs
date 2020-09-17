using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProductSales.Models;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ProductSales.DataAccess.CustomerRepository
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly IConfiguration _config;
    public IDbConnection Connection
    {
      get
      {
        return new SqlConnection(_config.GetConnectionString("DefaultConnectionString"));
      }
    }
    public CustomerRepository(IConfiguration config)
    {
      _config = config;
    }

    public async Task<bool> DeleteById(int id)
    {
      try
      {
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpCustomerDel";
          conn.Open();
          var customers = await conn.ExecuteAsync(storedProc, new { CustomerId = id }, commandType: CommandType.StoredProcedure);
          return true;
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.ToString());
        throw;
      }
    }

    public async Task<IEnumerable<Customer>> GetAll()
    {
      try
      {
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpCustomerSel";
          conn.Open();
          var customers = await conn.QueryAsync<Customer>(storedProc, null, commandType: CommandType.StoredProcedure);
          return customers.ToList();
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.ToString());
        throw;
      }
    }

    public async Task<bool> UpdateById(int id, Customer customer)
    {
      try
      {
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpCustomerUpd";
          conn.Open();
          var customers = await conn.ExecuteAsync(storedProc, new { CustomerId = id, customer.Address, customer.Name, customer.Phone }, commandType: CommandType.StoredProcedure);
          return true;
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.ToString());
        throw;
      }
    }

    public async Task<bool> AddCustomer(Customer customer)
    {
      try
      {
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpCustomerIns";
          conn.Open();
          var result = await conn.ExecuteAsync(storedProc, new { customer.Address, customer.Name, customer.Phone }, commandType: CommandType.StoredProcedure);
          return true;
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.ToString());
        throw;
      }
    }

    public async Task<Customer> GetCustomerById(int id)
    {
      try
      {
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpCustomerSel";
          conn.Open();
          var customers = await conn.QueryAsync<Customer>(storedProc, new { CustomerId = id }, commandType: CommandType.StoredProcedure);
          return customers.FirstOrDefault<Customer>();
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.ToString());
        throw;
      }
    }
  }
}
