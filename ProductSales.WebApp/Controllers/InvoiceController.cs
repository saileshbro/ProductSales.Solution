using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductSales.DataAccess.InvoiceRepository;

namespace ProductSales.WebApp.Controllers
{
  public class InvoiceController : Controller
  {
    private readonly IInvoiceRepository invoiceRepository;

    public InvoiceController(IInvoiceRepository invoiceRepository)
    {
      this.invoiceRepository = invoiceRepository;
    }

    public async Task<IActionResult> Index()
    {
      var invoices = await invoiceRepository.GetAll();
      return View(invoices);
    }
    public async Task<IActionResult> GenerateInovice(int id)
    {
      try
      {
        dynamic resp = await invoiceRepository.GenerateInvoice(id);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
    public async Task<IActionResult> GenerateInvoiceForAll()
    {
      try
      {
        dynamic resp = await invoiceRepository.GenerateInvoiceForAll();
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}
