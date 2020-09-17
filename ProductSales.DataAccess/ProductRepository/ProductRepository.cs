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

namespace ProductSales.DataAccess.ProductRepository
{
  public class ProductRepository : IProductRepository
  {
    private readonly IConfiguration _config;



    public IDbConnection Connection
    {
      get
      {
        return new SqlConnection(_config.GetConnectionString("DefaultConnectionString"));
      }
    }
    public ProductRepository(IConfiguration config)
    {
      _config = config;
    }

    public async Task<bool> DeleteById(int id)
    {
      try
      {
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpProductDel";
          conn.Open();
          var products = await conn.ExecuteAsync(storedProc, new { ProductId = id }, commandType: CommandType.StoredProcedure);
          return true;
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.ToString());
        throw;
      }
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
      try
      {
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpProductSel";
          conn.Open();
          var products = await conn.QueryAsync<Product>(storedProc, null, commandType: CommandType.StoredProcedure);
          return products.ToList();
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.ToString());
        throw;
      }
    }

    public async Task<bool> UpdateById(int id, Product product)
    {
      try
      {
        product.ProductId = id;
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpProductUpd";
          conn.Open();
          var products = await conn.ExecuteAsync(storedProc, product, commandType: CommandType.StoredProcedure);
          return true;
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.ToString());
        throw;
      }
    }

    public async Task<bool> AddProduct(Product product)
    {
      try
      {
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpProductIns";
          conn.Open();
          var result = await conn.ExecuteAsync(storedProc, new { product.Name, product.Price, product.BarCode }, commandType: CommandType.StoredProcedure);
          return true;
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.ToString());
        throw;
      }
    }

    public async Task<Product> GetProductById(int id)
    {
      try
      {
        using (IDbConnection conn = Connection)
        {
          string storedProc = "SpProductSel";
          conn.Open();
          var products = await conn.QueryAsync<Product>(storedProc, new { ProductId = id }, commandType: CommandType.StoredProcedure);
          return products.FirstOrDefault<Product>();
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
