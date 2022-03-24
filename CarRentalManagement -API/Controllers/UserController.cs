using CarRentalManagement___DataAccessLayer.DTO;
using CarRentalManagement___DataAccessLayer.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement__API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            using (CarDBContext dbContext = new CarDBContext())
            {
                return dbContext.UserDtos.ToList();
            }
        }
    }
}
