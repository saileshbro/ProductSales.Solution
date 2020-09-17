using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSales.Models
{
  public class Customer
  {
    public int CustomerId { get; set; }
    [Required(ErrorMessage = "Customer Name required!")]
    [StringLength(150, MinimumLength = 3)]
    [Display(Name = "Customer Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Phone number required!")]
    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone Number")]
    [StringLength(15, MinimumLength = 10, ErrorMessage = "Invalid phone number provided")]
    public string Phone { get; set; }
    [DisplayFormat(NullDisplayText = "NA")]
    [Display(Name = "Address")]
    public string Address { get; set; }
  }
}
