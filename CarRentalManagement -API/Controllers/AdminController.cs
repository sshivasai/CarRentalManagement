using CarRentalManagement___DataAccessLayer.DTO;
using CarRentalManagement___DataAccessLayer.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement__API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<AdminDto> Get()
        {
            using (CarDBContext dbContext = new CarDBContext())
            {
                return dbContext.AdminDtos.ToList();
            }
        }
        [HttpGet("id")]
        public AdminDto Get(int? id)
        {
            using (CarDBContext? dbContext = new CarDBContext())
            {
                return dbContext.AdminDtos.FirstOrDefault(e => e.AdminId == id);
            }
        }
        [HttpPut]
        public void Put(int id, [FromBody] AdminDto AdminDto)
        {
            using (CarDBContext dbContext = new CarDBContext())
            {
                var entity = dbContext.AdminDtos.FirstOrDefault(e => e.AdminId == id);
                entity.AdminId = id;
                entity.FName = AdminDto.FName;
                entity.LName = AdminDto.LName;
                entity.Password = AdminDto.Password;
                entity.Email = AdminDto.Email;
                entity.OrderDetails = null;
                entity.PhoneNumber= AdminDto.PhoneNumber;

                dbContext.SaveChanges();
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            using (CarDBContext dbContext = new CarDBContext())
            {
                dbContext.AdminDtos.Remove(dbContext.AdminDtos.FirstOrDefault(e => e.AdminId == id));
                dbContext.SaveChanges();
            }
        }
        [HttpPost]
        public void Post([FromBody] AdminDto adminDto)
        {
            using (CarDBContext dbContext = new CarDBContext())
            {
                dbContext.AdminDtos.Add(adminDto);
                dbContext.SaveChanges();
            }
        }

    }
}
