using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSales.DataAccess.ProductRepository;
using ProductSales.Models;

namespace ProductSales.WebApp.Controllers
{
  public class ProductController : Controller
  {
    private readonly IProductRepository productRepository;

    public ProductController(IProductRepository productRepository)
    {
      this.productRepository = productRepository;
    }

    public async Task<IActionResult> Index()
    {
      IEnumerable<Product> products = await productRepository.GetAll();
      return View(products);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
      try
      {
        await productRepository.AddProduct(product);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    public async Task<IActionResult> Edit(int id)
    {
      Product product = await productRepository.GetProductById(id);
      return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product product)
    {
      try
      {
        var update = await productRepository.UpdateById(id, product);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        await productRepository.DeleteById(id);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return RedirectToAction(nameof(Index));
      }
    }
  }
}
