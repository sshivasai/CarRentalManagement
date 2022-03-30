using CarRentalManagement_DAL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement_DAL.Repository.IRepository
{
    public interface ICarCategoryRepository : IRepository<CarCategory>
    {
        void Update(CarCategory obj);
        //void Save();
    }
}
