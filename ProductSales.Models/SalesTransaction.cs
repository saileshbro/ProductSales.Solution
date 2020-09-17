using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSales.Models
{
  public class SalesTransaction
  {
    [Required(ErrorMessage = "Customer id is required!")]
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerAddress { get; set; }

    [Required(ErrorMessage = "Product id is required!")]
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string BarCode { get; set; }
    public double Rate { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Invalid quantity provided")]
    public int Quantity { get; set; }

    [DataType(DataType.Currency)]
    public double Total { get; set; }
    [DisplayFormat(NullDisplayText = "NA")]
    public int? InvoiceId { get; set; }
  }
}
