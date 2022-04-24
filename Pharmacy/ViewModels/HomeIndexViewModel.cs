using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Medicine> Medicines { get; set; }
        public IEnumerable<Carousel> Carousels { get; set; }
    }
}
