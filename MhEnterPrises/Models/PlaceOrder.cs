using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MhEnterPrises.Models
{
    public class PlaceOrder
    {

        public int id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Contact")]
        public string Contact { get; set; }

        [Display(Name = "Product")]
        public string Product { get; set; }


        [Display(Name = "Qty")]
        public int Qty { get; set; }

        public HomeAppliances homeAppliances { get; set; }


    }
}
