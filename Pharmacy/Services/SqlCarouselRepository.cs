using Pharmacy.Data;
using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services
{
    public class SqlCarouselRepository:IRepository<Carousel>
    {
        private PharmacyDbContext _context;

        public SqlCarouselRepository(PharmacyDbContext context)
        {
            _context = context;
        }
        public bool Add(Carousel item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Carousel Item)
        {
            try
            {
                Carousel medicine = Get(Item.Id);
                if (medicine != null)
                {
                    _context.Remove(Item);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Carousel item)
        {
            throw new NotImplementedException();
        }

        public Carousel Get(int id)
        {
            if (_context.Carousels.Count(x => x.Id == id) > 0)
            {
                return _context.Carousels.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public IEnumerable<Carousel> GetAll()
        {
            return _context.Carousels;
        }

        public List<Carousel> GetAllByCarousel(int id)
        {
            throw new NotImplementedException();
        }
    }
}
