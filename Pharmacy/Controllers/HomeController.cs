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
        //List<Book> _book;
        IRepository<Order> _orderRepo;
        IRepository<Medicine> _medicineRepo;
        IRepository<Carousel> _CarouselRepo;

        public HomeController(IRepository<Medicine> medicine, IRepository<Carousel> carousel, IRepository<Order> order)
        {
            //_book = new List<Book>();
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
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                Medicine item = new Medicine()
                {
                    Id = _medicineRepo.GetAll().Max(m => m.Id) + 1,
                    Title = medicine.Title,
                    Description = medicine.Description,
                    Price = medicine.Price,
                    Image = medicine.Image
                };
                _medicineRepo.Add(item);
                return RedirectToAction("Index");
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
        public IActionResult BookList(int id)
        {
            return View(_medicineRepo.GetAllByCarousel(id));
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}