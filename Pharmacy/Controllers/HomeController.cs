using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Models;
using Pharmacy.Services;
using Pharmacy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Order> _orderRepo;
        IRepository<Medicine> _medicineRepo;
        IRepository<Carousel> _CarouselRepo;

        public HomeController(IRepository<Medicine> medicine, IRepository<Carousel> carousel, IRepository<Order> order)
        {
            _medicineRepo = medicine;
            _CarouselRepo = carousel;
            _orderRepo = order;
        }

        //The home page
        public IActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel()
            {
                Medicines = _medicineRepo.GetAll(),
                Carousels = _CarouselRepo.GetAll()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult AddMedicine()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMedicine(Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                Medicine item = new Medicine()
                {
                    Title = medicine.Title,
                    Description = medicine.Description,
                    Ingredients = medicine.Ingredients,
                    ExpirationDate = medicine.ExpirationDate,
                    Price = medicine.Price,
                    Image = medicine.Image,
                    CarouselId = 1
                };
                _medicineRepo.Add(item);
                return RedirectToAction("medicinelist");

            }
            else
            {
                return View();
            }
        }

        //The about page
        public IActionResult About()
        {
            return View();
        }

        //The contact us page
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            Medicine medicine = _medicineRepo.Get(id);
            return View(medicine);
        }

        [HttpGet]
        public IActionResult Order(int? id)
        {
            if (id != null && id >= 0)
            {
                OrderViewModel model = new OrderViewModel()
                {
                    MedicineToOrder = _medicineRepo.Get((int)id),
                    OrderDetails = new Order
                    {
                        MedicineId = (int)id
                    }
                };

                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Order(int id, Order orderDetails)
        {
            if (ModelState.IsValid)
            {
                if(_medicineRepo.GetAll().Count(x => x.Id == orderDetails.MedicineId) >= 0)
                {
                    orderDetails.MedicineId = id;
                    _orderRepo.Add(orderDetails);
                    return RedirectToAction("ThankYou");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View(new OrderViewModel()
                {
                   OrderDetails = orderDetails,
                   MedicineToOrder = _medicineRepo.Get(id)
                });
            }
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        public IActionResult OrderList()
        {
            return View(_orderRepo.GetAll());
        }
        public IActionResult MedicineList(int id)
        {
            return View(_medicineRepo.GetAllByCarousel(id));
        }

        public IActionResult EditMedicine(int id)
        {
            return View(_medicineRepo.Get(id));
        }

        [HttpPost]
        public IActionResult EditMedicine(Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                Medicine existingMedicine = _medicineRepo.Get(medicine.Id);
                if (existingMedicine != null)
                {
                    existingMedicine.Title = medicine.Title;
                    existingMedicine.Description = medicine.Description;
                    existingMedicine.Ingredients = medicine.Ingredients;
                    existingMedicine.ExpirationDate = medicine.ExpirationDate;
                    existingMedicine.Image = medicine.Image;
                    existingMedicine.Price = medicine.Price;
                    _medicineRepo.Edit(existingMedicine);
                }
                return RedirectToAction("medicinelist/" + existingMedicine.CarouselId);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Medicine existingMedicine = _medicineRepo.Get(id);
            _medicineRepo.Delete(existingMedicine);
            return RedirectToAction("medicinelist/" + existingMedicine.CarouselId);
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}