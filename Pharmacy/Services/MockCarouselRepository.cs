using Pharmacy.Models;
using Pharmacy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePacktPharmacy.Services
{
	public class MockCarouselRepository : IRepository<Carousel>
	{
		List<Carousel> _carousels;
		public MockCarouselRepository()
		{
			_carousels = new List<Carousel>();
			_carousels.Add(new Carousel()
			{
				Id = 0,
				Title = "Discount books",
				Description = "Discount books get them all",
				ImageURL = "~/Images/images (1).jpg"
            });
			_carousels.Add(new Carousel()
			{
				Id = 2,
				Title = "New books",
				Description = "All brand new books ",
				ImageURL = "~/Images/images (3).jpg"
            });
			_carousels.Add(new Carousel()
			{
				Id = 3,
				Title = "Subcription",
				Description = "Discount on monthly subcription",
				ImageURL = "~/Images/images.jpg"
            });
		}
		public bool Add(Carousel item)
		{
			try
			{
				Carousel carousel = item;
				carousel.Id = _carousels.Max(x => x.Id) + 1;
				_carousels.Add(carousel);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool Delete(Carousel Item)
		{
			throw new NotImplementedException();
		}

		public bool Edit(Carousel item)
		{
			throw new NotImplementedException();
		}

		public Carousel Get(int id)
		{
			return _carousels.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Carousel> GetAll()
		{
			return _carousels.ToList();
		}

        public List<Carousel> GetAllByCarousel(int id)
        {
            throw new NotImplementedException();
        }
    }
}
