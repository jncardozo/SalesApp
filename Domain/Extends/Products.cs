using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [MetadataType(typeof(ProductsMetadata))]
    public partial class Products
    {
        #region Properties
        public string CompleteName => $"{Name} {Supplier}";        
        #endregion
    }

    public class ProductsMetadata
    {
        [Required(ErrorMessage = "Field Product Name is required ")]
        [Display(Name = "Product Name")]        
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Brand is required ")]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Display(Name = "Expiration Date")]
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        
        [Display(Name = "Unit Price")]
        public Nullable<decimal> UnitPrice { get; set; }

        [Required(ErrorMessage = "Field Supplier is required ")]
        [Display(Name = "Supplier")]
        public string Supplier { get; set; }
    }

}