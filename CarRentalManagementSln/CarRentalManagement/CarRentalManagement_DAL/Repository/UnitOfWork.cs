using CarRentalManagement_DAL.Repository.Context;
using CarRentalManagement_DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement_DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _db;

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            CarCategory = new CarCategoryRepository(_db);
            Manufacturer = new ManufacturerRepository(_db);
            Car = new CarRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);  
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);

        }
        public ICarCategoryRepository CarCategory { get; private set; }
        public IManufacturerRepository Manufacturer { get; private set; }
        public ICarRepository Car { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public IShoppingCartRepository ShoppingCart { get; private set; }

        public IOrderDetailRepository OrderDetail { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
