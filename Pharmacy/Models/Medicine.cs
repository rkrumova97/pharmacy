using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class Medicine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CarouselId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Medicine Title"), MinLength(2, ErrorMessage = "Minimum length is 2 chars")]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public string ExpirationDate { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Please enter correct price.")]
        public double Price { get; set; }

        public string Image { get; set; }
    }
}
