using Pharmacy.Data;
using Pharmacy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services
{
    public class SqlMedicineRepository : IRepository<Medicine>
    {
        private PharmacyDbContext _context;

        public SqlMedicineRepository(PharmacyDbContext context)
        {
            _context = context;
        }
        public bool Add(Medicine item)
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

        public bool Delete(Medicine Item)
        {
            try
            {
                Medicine medicine = Get(Item.Id);
                if(medicine != null)
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

        public bool Edit(Medicine item)
        {
            throw new NotImplementedException();
        }

        public Medicine Get(int id)
        {
            if (_context.Medicines.Count(x => x.Id == id) > 0)
            {
                return _context.Medicines.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _context.Medicines;
        }

        public List<Medicine> GetAllByCarousel(int carouselId)
        {
            DbSet<Medicine> medicines = _context.Medicines;
            List<Medicine> result = new List<Medicine>();
            foreach(Medicine b in medicines)
            {
                if (carouselId.Equals(b.CarouselId))
                {
                    result.Add(b);
                }
            }
            return result;
        }     
    }
}
