using CarRentalManagement_DAL.Dto;
using CarRentalManagement_DAL.Repository.IRepository;
using CarRentalManagement_DAL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CarRentalManagement_UI.Controllers;
[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;


    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult About()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Index()
    {
        IEnumerable<Car> carList = _unitOfWork.Car.GetAll(includeProperties: "Manufacturer,CarCategory");
        return View(carList);
    }
    public IActionResult Details(int carId)
    {
        ShoppingCart ShoppingCart = new() {
            
           
            CarId = carId,
        Car = _unitOfWork.Car.GetFirstOrDefault(u => u.Id == carId, includeProperties: "Manufacturer,CarCategory")
    };
        return View(ShoppingCart);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public IActionResult Details(ShoppingCart shoppingCart)
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        shoppingCart.ApplicationUserId = claim.Value;
        _unitOfWork.ShoppingCart.Add(shoppingCart);
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
        //return View(
        //);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
