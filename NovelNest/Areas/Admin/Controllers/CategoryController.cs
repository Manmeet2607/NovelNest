

using Microsoft.AspNetCore.Mvc;
using NovelNest.Models.Models;
using NovelNest.Repository.IRepository;

namespace NovelNest.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles=SD.Role_Admin)]

    public class CategoryController : Controller
    {

        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _UnitOfWork;

        public CategoryController(IUnitOfWork db)
        {
            _UnitOfWork = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _UnitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name");
            }
            if (obj.Name == "test")
            {
                ModelState.AddModelError("", "Invalid Value");
            }
            if (ModelState.IsValid)
            {
                _UnitOfWork.Category.Add(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }




        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _UnitOfWork.Category.Get(u => u.Id == Id);
            //Category? categoryFromDb=_db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category categoryFromDb=_db.Categories.where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromDb == null) { return NotFound(); }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {


            if (ModelState.IsValid)
            {
                _UnitOfWork.Category.Update(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Category Updated successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }







        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _UnitOfWork.Category.Get(u => u.Id == Id);
            //Category? categoryFromDb=_db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category categoryFromDb=_db.Categories.where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromDb == null) { return NotFound(); }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? Id)
        {

            Category? obj = _UnitOfWork.Category.Get(u => u.Id == Id);
            if (obj == null) { return NotFound(); }
            _UnitOfWork.Category.Remove(obj);
            _UnitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index", "Category");
        }

    }
}
