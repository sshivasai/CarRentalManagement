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
    public class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository
    {
        private ApplicationDBContext _db;

        public ManufacturerRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Manufacturer obj)
        {
            _db.Manufacturers.Update(obj);
        }
    }
}
