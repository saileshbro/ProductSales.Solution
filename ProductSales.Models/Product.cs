using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSales.Models
{
  public class Product
  {
    public int ProductId { get; set; }
    [Required]
    [Display(Name = "Product Name")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "Invalid product name provided")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Price")]
    [DataType(DataType.Currency)]
    public double Price { get; set; }

    [Display(Name = "Bar code")]
    [DisplayFormat(NullDisplayText = "NA")]
    public string BarCode { get; set; }
  }
}
