using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a medicine")]
        public int MedicineId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select a name")]
        public string ClientName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select a street")]
        public string Street { get; set; }

        public string State { get; set; }
        public string Perscription { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select a country")]
        public string Country { get; set; }

        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Please select a zip code")]
        public string Zip { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please add your phone")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please add your email")]
        public string Email { get; set; }

    }
}
