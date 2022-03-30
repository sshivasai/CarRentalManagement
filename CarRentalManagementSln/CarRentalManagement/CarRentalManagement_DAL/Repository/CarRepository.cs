using CarRentalManagement_DAL.Dto;
using CarRentalManagement_DAL.Repository.Context;
using CarRentalManagement_DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement_DAL.Repository
{
    public class CarCategoryRepository : Repository<CarCategory>, ICarCategoryRepository
    {
        private ApplicationDBContext _db;

        public CarCategoryRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }


        public void Update(CarCategory obj)
        {
            _db.CarCategories.Update(obj);
            
        }
        //public void Save()
        //{
        //    _db.SaveChanges();
        //}
       
    }
}
