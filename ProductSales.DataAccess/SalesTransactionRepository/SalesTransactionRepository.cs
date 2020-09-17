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

namespace ProductSales.DataAccess.SalesTransactionRepository
{
  public class SalesTransactionRepository : ISalesTransactionRepository
  {
    private readonly IConfiguration _config;



    public IDbConnection Connection
    {
      get
      {
        return new SqlConnection(_config.GetConnectionString("DefaultConnectionString"));
      }
    }
    public SalesTransactionRepository(IConfiguration config)
    {
      _config = config;
    }

    public async Task<IEnumerable<SalesTransaction>> GetAll()
    {
      try
      {
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpSalesTransactionSel";
          conn.Open();
          var salesTransactions = await conn.QueryAsync<SalesTransaction>(storedProc, null, commandType: CommandType.StoredProcedure);
          return salesTransactions.ToList();
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.ToString());
        throw;
      }
    }

    public async Task<bool> AddSalesTransaction(SalesTransaction salesTransaction)
    {
      try
      {
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpSalesTransactionIns";
          conn.Open();
          var result = await conn.ExecuteAsync(storedProc, new { salesTransaction.ProductId, salesTransaction.CustomerId, salesTransaction.Quantity }, commandType: CommandType.StoredProcedure);
          return true;
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
