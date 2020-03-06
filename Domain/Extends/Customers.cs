using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [MetadataType(typeof(CustomersMetadata))]
    public partial class Customers
    {
        #region Properties
        public string CompleteName => $"{Name} {Surname}";
        #endregion
    }

    public class CustomersMetadata
    {
        [Required(ErrorMessage = "Field Customer Name is required ")]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Customer Surname is required ")]
        [Display(Name = "Customer Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Field Document Number is required ")]
        [Display(Name = "Document Number")]
        public string DocNum { get; set; }
        
        [Display(Name = "Birth Day")]
        public Nullable<System.DateTime> BirthDate { get; set; }
        
        [Display(Name = "Age of Customer")]
        public Nullable<int> Age { get; set; }

        [Required(ErrorMessage = "Field Credit Card Number is required ")]
        [Display(Name = "Credit Card Number")]
        public string CreditCard { get; set; }        
    }
}
