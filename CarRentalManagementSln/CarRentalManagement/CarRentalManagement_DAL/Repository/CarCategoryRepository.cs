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
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private ApplicationDBContext _db;

        public CarRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Car obj)
        {
            var objFromDb = _db.Cars.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Year = obj.Year;
                objFromDb.DefaultPrice = obj.DefaultPrice;

                objFromDb.PricePerWeek = obj.PricePerWeek;
                objFromDb.PricePerDay = obj.PricePerDay;
                objFromDb.PricePerMonth = obj.PricePerMonth;
                objFromDb.Description = obj.Description;
                objFromDb.ManufacturerId = obj.ManufacturerId;
                objFromDb.Stock = obj.Stock;
                objFromDb.CarCategoryId = obj.CarCategoryId;
                objFromDb.Gears = obj.Gears;
                objFromDb.Transmission = obj.Transmission;
                objFromDb.Condition = obj.Condition;
                
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
        //public void Save()
        //{
        //    _db.SaveChanges();
        //}
    }
}
