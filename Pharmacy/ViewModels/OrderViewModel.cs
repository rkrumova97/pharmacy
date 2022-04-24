using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.ViewModels
{
    public class OrderViewModel
    {
        public Medicine MedicineToOrder { get; set; }
        public Order OrderDetails { get; set; }
    }
}
