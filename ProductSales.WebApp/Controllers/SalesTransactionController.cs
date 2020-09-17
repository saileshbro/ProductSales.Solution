using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductSales.DataAccess.SalesTransactionRepository;
using ProductSales.Models;

namespace ProductSales.WebApp.Controllers
{
  public class SalesTransactionController : Controller
  {
    private readonly ISalesTransactionRepository salesTransactionRepository;

    public SalesTransactionController(ISalesTransactionRepository salesTransactionRepository)
    {
      this.salesTransactionRepository = salesTransactionRepository;
    }

    public async Task<IActionResult> Index()
    {
      var salesTransactions = await salesTransactionRepository.GetAll();
      return View(salesTransactions);
    }
    public IActionResult Create()
    {
      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SalesTransaction salesTransaction)
    {
      try
      {
        dynamic resp = await salesTransactionRepository.AddSalesTransaction(salesTransaction);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

  }
}
