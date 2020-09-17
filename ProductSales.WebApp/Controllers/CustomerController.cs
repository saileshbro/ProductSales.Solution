using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSales.DataAccess.CustomerRepository;
using ProductSales.Models;
using ProductSales.WebApp.Models;

namespace ProductSales.WebApp.Controllers
{
  public class CustomerController : Controller
  {
    public readonly ICustomerRepository customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
      this.customerRepository = customerRepository;
    }

    public async Task<IActionResult> Index()
    {
      var customers = await customerRepository.GetAll();
      return View(customers);
    }
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Customer customer)
    {
      try
      {
        dynamic resp = await customerRepository.AddCustomer(customer);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
    // GET: ProductController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
      Customer customer = await customerRepository.GetCustomerById(id);
      return View(customer);
    }

    // POST: ProductController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Customer customer)
    {
      try
      {
        var update = await customerRepository.UpdateById(id, customer);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }


    // GET: ProductController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        await customerRepository.DeleteById(id);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return RedirectToAction(nameof(Index));
      }
    }

  }
}
