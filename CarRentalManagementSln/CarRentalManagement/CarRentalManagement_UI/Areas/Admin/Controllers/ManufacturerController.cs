
using CarRentalManagement_DAL.Dto;
using CarRentalManagement_DAL.Repository.Context;
using CarRentalManagement_DAL.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CarRentalManagement_UI.Controllers;

[Area("Admin")]
[Authorize]
public class ManufacturerController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ManufacturerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        IEnumerable<Manufacturer> objManufacturerList = _unitOfWork.Manufacturer.GetAll();
        return View(objManufacturerList);
    }
    //Get
    public IActionResult Create()
    {

        return View();
    }
    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Manufacturer obj)

    {
        var objFromDb = _unitOfWork.Manufacturer.GetFirstOrDefault(u => u.Name == obj.Name);
        if (objFromDb == null)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Manufacturer.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Manufacturer /Brand Partner added successfully";
                return RedirectToAction("Index");
            }

        }
        else if (obj.Name == objFromDb.Name.ToString())
        {
            ModelState.AddModelError("name", "Manufacturer/Brand Partner is already present in the Database");
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
        

        var ManufacturerFromDb = _unitOfWork.Manufacturer.GetFirstOrDefault(u => u.Id == id);
        if (ManufacturerFromDb == null)
        {
            return NotFound();
        }
        return View(ManufacturerFromDb);
    }
    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Manufacturer obj)

    {


        if (ModelState.IsValid)
        {
            _unitOfWork.Manufacturer.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Manufacturer / Partner details updated successfully";
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
        
        var ManufacturerFromDb = _unitOfWork.Manufacturer.GetFirstOrDefault(u => u.Id == id);
        if (ManufacturerFromDb == null)
        {
            return NotFound();
        }
        return View(ManufacturerFromDb);
    }
    //Post
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)

    {
        var obj = _unitOfWork.Manufacturer.GetFirstOrDefault(u => u.Id == id);

        if (obj == null)
        {
            return NotFound();
        }


        _unitOfWork.Manufacturer.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Manufacturer/Brand Partner deleted successfully";
        return RedirectToAction("Index");

    }
}







