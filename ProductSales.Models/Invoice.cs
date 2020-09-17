using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace ProductSales.Models
{
  public class Invoice
  {
    public int InvoiceId { get; set; }
    public int CustomerId { get; set; }
    public DateTime Date { get; set; }
    public double Total;
  }
}
