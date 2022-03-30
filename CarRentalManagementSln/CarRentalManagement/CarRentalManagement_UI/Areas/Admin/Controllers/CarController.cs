
using CarRentalManagement_DAL.Dto;
using CarRentalManagement_DAL.Repository.Context;
using CarRentalManagement_DAL.Repository.IRepository;
using CarRentalManagement_DAL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalManagement_UI.Controllers;

[Area("Admin")]
[Authorize]
public class CarController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;


    public CarController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _hostEnvironment = hostEnvironment;
    }

    public IActionResult Index()
    {
        return View();
    }

    //GET
    public IActionResult Upsert(int? id)
    {
        CarVM carVM = new()
        {
            Car = new(),
            CarCategoryList = _unitOfWork.CarCategory.GetAll().Select(i => new SelectListItem
            {
                Text = i.CategoryName,
                Value = i.Id.ToString()
            }),
            ManufacturerList = _unitOfWork.Manufacturer.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }),
        };

        if (id == null || id == 0)
        {
            
            return View(carVM);
        }
        else
        {
            carVM.Car = _unitOfWork.Car.GetFirstOrDefault(u => u.Id == id);
            return View(carVM);

            
        }


    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(CarVM obj, IFormFile? file)
    {

        if (ModelState.IsValid)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\cars");
                var extension = Path.GetExtension(file.FileName);

                if (obj.Car.ImageUrl != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.Car.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                obj.Car.ImageUrl = @"\images\cars\" + fileName + extension;

            }
            if (obj.Car.Id == 0)
            {
                _unitOfWork.Car.Add(obj.Car);
                TempData["success"] = "Car Added successfully";
            }
            else
            {
                _unitOfWork.Car.Update(obj.Car);
                TempData["success"] = "Car Updated successfully";
            }
            _unitOfWork.Save();
          
            return RedirectToAction("Index");
        }
        return View(obj);
    }



    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
        var carList = _unitOfWork.Car.GetAll(includeProperties: "CarCategory,Manufacturer");
        return Json(new { data = carList });
    }

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Car.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

        var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
        if (System.IO.File.Exists(oldImagePath))
        {
            System.IO.File.Delete(oldImagePath);
        }

        _unitOfWork.Car.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successfull" });

    }
    #endregion

}




