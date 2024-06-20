using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelNest.Models.Models;
using NovelNest.Repository.IRepository;
using System.Diagnostics;
using System.Security.Claims;

namespace NovelNest.Areas.Customer.Controllers
{
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

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");

            return View(productList);
        }

        public IActionResult Details(int productid)
        {

            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Product.Get(u => u.Id == productid, includeProperties: "Category"),
                Count = 1,
                ProductId = productid
            };

            return View(cart);
        }

        [HttpPost]
        [Authorize] // to get userid of user that is logged in
        public IActionResult Details(ShoppingCart shoppingcart)
        {

            //to get user id of logged in user we have these default methods
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingcart.ApplicationUserId = userId;
            //to check if the user doesnt already exist with the shopping cart.If exists we update the user cart else add new user to it.
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId && u.ProductId == shoppingcart.ProductId);
            if (cartFromDb != null)
            {
                cartFromDb.Count += shoppingcart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);  //update the already present cart in db with the new count
                //even if we dont write the update when we change the count and do the save command it automatically updates first
                _unitOfWork.Save();
            }
            else
            {
                _unitOfWork.ShoppingCart.Add(shoppingcart);
                _unitOfWork.Save();
            }
            TempData["success"] = "Cart updated successfully";
            return RedirectToAction("Index");
            //return RedirectToAction(nameof(Index);
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
}