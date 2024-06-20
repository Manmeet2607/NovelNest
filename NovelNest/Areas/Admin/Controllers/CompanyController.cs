

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using NovelNest.Models.Models;
using NovelNest.Models.ViewModels;
using NovelNest.Repository.IRepository;
using NovelNest.Utility;

namespace NovelNest.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return View(objCompanyList);
        }
        public IActionResult Upsert(int? id)
        {
            //IEnumerable<SelectListItem> CategoryList = 
            //    _UnitOfWork.Category.GetAll().Select(u => new SelectListItem
            //{
            //    Text = u.Name,
            //    Value = u.Id.ToString(),
            //});
            //ViewBag.CategoryList = CategoryList;
            //ViewData["CategoryList"]=CategoryList;

            //CompanyVM CompanyVM = new CompanyVM()
            //{
            //    Company = new Company(),
            //    CategoryList = CategoryList
            //};




            if (id == null || id == 0)
            {
                //create
                return View(new Company());
            }
            else
            {
                //update
                Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyObj);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {


            if (ModelState.IsValid)
            {

                if (CompanyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(CompanyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(CompanyObj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index", "Company");
            }
            return View(CompanyObj);
        }
 


//public IActionResult Delete(int? Id)
//{
//    if (Id == null || Id == 0)
//    {
//        return NotFound();
//    }

//    Company? productFromDb = _unitOfWork.Company.Get(u => u.Id == Id);
//    //Company? categoryFromDb=_db.Categories.FirstOrDefault(u=>u.Id==id);
//    //Company categoryFromDb=_db.Categories.where(u=>u.Id==id).FirstOrDefault();
//    if (productFromDb == null) { return NotFound(); }
//    return View(productFromDb);
//}

//[HttpPost, ActionName("Delete")]
//public IActionResult DeletePOST(int? Id)
//{

//    Company? obj = _unitOfWork.Company.Get(u => u.Id == Id);
//    if (obj == null) { return NotFound(); }
//    _unitOfWork.Company.Remove(obj);
//    _unitOfWork.Save();
//    TempData["success"] = "Company deleted successfully";
//    return RedirectToAction("Index", "Company");
//}

#region API CALLS
[HttpGet]
public IActionResult GetAll(int id)
{
    List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
    return Json(new { data = objCompanyList });
}

[HttpDelete]
public IActionResult Delete(int? id)
{
    var productToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
    if (productToBeDeleted == null)
    {
        return Json(new { success = false, message = "Error While Deleting" });
    }
    
    _unitOfWork.Company.Remove(productToBeDeleted);
    _unitOfWork.Save();
    return Json(new { success = true, message = "Delete Successful" });

}


        #endregion

    }
}