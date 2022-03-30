
using CarRentalManagement_DAL.Dto;
using CarRentalManagement_DAL.Repository.Context;
using CarRentalManagement_DAL.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CarRentalManagement_UI.Controllers;

[Area("Admin")]
[Authorize]
public class CarCategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CarCategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    //gett operation
    public IActionResult Index()
    {
        IEnumerable<CarCategory> objCarCategoryList = _unitOfWork.CarCategory.GetAll();
        return View(objCarCategoryList);

        
    }
    //Get
    public IActionResult Create()
    {

        return View();
    }
    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CarCategory obj)

    {
        var objFromDb = _unitOfWork.CarCategory.GetFirstOrDefault(u => u.CategoryName == obj.CategoryName);
        if (objFromDb == null)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CarCategory.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

        }
        else if (obj.CategoryName == objFromDb.CategoryName.ToString())
        {
            ModelState.AddModelError("categoryName", "Category is already present in the Database");
            return View(obj);
        }
        return View(obj);
    }
    //Get
    public IActionResult Edit(int? id)
    {
        if (id == 0 || id == null)
        {
            return NotFound();
        }
        //var carCategoryFromDb = _db.CarCategories.Find(id);
        var carCategoryFromDb = _unitOfWork.CarCategory.GetFirstOrDefault(u => u.Id == id);
        if (carCategoryFromDb == null)
        {
            return NotFound();
        }
        return View(carCategoryFromDb);
    }
    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CarCategory obj)

    {


        if (ModelState.IsValid)
        {
            _unitOfWork.CarCategory.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }
    
    //Get
    public IActionResult Delete(int? id)
    {
        if (id == 0 || id == null)
        {
            return NotFound();
        }
        //var carCategoryFromDb = _db.CarCategories.Find(id);
        var carCategoryFromDb = _unitOfWork.CarCategory.GetFirstOrDefault(u => u.Id == id);
        if (carCategoryFromDb == null)
        {
            return NotFound();
        }
        return View(carCategoryFromDb);
    }
    //Post
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)

    {
        var obj = _unitOfWork.CarCategory.GetFirstOrDefault(u => u.Id == id);

        if (obj == null)
        {
            return NotFound();
        }


        _unitOfWork.CarCategory.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");

    }
}







