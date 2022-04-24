using Pharmacy.Models;
using Pharmacy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePackPharmacy.Services
{
    public class MockMedicineRepository : IRepository<Medicine>
    {
        List<Medicine> _medicines;
        public MockMedicineRepository()
        {
            _medicines = new List<Medicine>() {
                new Medicine()
                {
                    //TODO - change to medicines
                    Id = 0,
                    Title = "JavaScript and JSON Essentials",
                    Description = "Use JSON for building web applications with technologies like HTML, JavaScript, Angular, Node.js, Hapi.js, Kafka, socket.io, MongoDB, Gulp.js, and handlebar.js, and others formats like GEOJSON, JSON-LD, MessagePack, and BSON.",
                    Price = 30,
                    Image = "images (1).jpg"
                },
                new Medicine()
                {
                    Id = 1,
                    Title = "C# and .NET Core Test Driven Development",
                    Description = "Learn how to apply a test-driven development process by building ready C# 7 and .NET Core applications.",
                    Price = 25,
                    Image = "images (3).jpg"
                },
                new Medicine()
                {
                    Id = 2,
                    Title = "ASP.NET Core 2 and Angular 5",
                    Description = "Develop a simple, yet fully-functional modern web application using ASP.NET Core MVC, Entity Framework and Angular 5.",
                    Price = 20,
                    Image = "images.jpg"
                }

            };
           
        }
        public bool Add(Medicine item)
        {
            try
            {
                Medicine medicine = item;
                medicine.Id = _medicines.Max(x => x.Id) + 1;
                _medicines.Add(medicine);
                return true;
            }
            catch (Exception)
            {
                //Log it here
                return false;
            }
        }

        public bool Delete(Medicine Item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Medicine item)
        {
            throw new NotImplementedException();
        }

        public Medicine Get(int id)
        {
            return _medicines.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _medicines.ToList();
        }

        public List<Medicine> GetAllByCarousel(int id)
        {
            throw new NotImplementedException();
        }
    }
}
