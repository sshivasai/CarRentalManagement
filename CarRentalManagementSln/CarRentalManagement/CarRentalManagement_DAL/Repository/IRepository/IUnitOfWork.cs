using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement_DAL.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICarCategoryRepository CarCategory { get; }
        IManufacturerRepository Manufacturer { get; }
        ICarRepository Car { get; }
        IApplicationUserRepository ApplicationUser { get; } 
        IShoppingCartRepository ShoppingCart { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailRepository OrderDetail { get; }
        void Save();
    }
}
