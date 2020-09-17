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

namespace ProductSales.DataAccess.InvoiceRepository
{
  public class InvoiceRepository : IInvoiceRepository
  {
    private readonly IConfiguration _config;



    public IDbConnection Connection
    {
      get
      {
        return new SqlConnection(_config.GetConnectionString("DefaultConnectionString"));
      }
    }
    public InvoiceRepository(IConfiguration config)
    {
      _config = config;
    }


    public async Task<bool> GenerateInvoice(int customerId)
    {
      try
      {
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpInvoiceIns";
          conn.Open();
          var result = await conn.ExecuteAsync(storedProc, new { CustomerId = customerId }, commandType: CommandType.StoredProcedure);
          return true;
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.ToString());
        throw;
      }
    }

    public async Task<bool> GenerateInvoiceForAll()
    {
      try
      {
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpInvoiceIns";
          conn.Open();
          var result = await conn.ExecuteAsync(storedProc, null, commandType: CommandType.StoredProcedure);
          return true;
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.ToString());
        throw;
      }
    }

    public async Task<IEnumerable<Invoice>> GetAll()
    {
      try
      {
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpInvoiceSel";
          conn.Open();
          var invoices = await conn.QueryAsync<Invoice>(storedProc, null, commandType: CommandType.StoredProcedure);
          return invoices.ToList();
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
