using Microsoft.AspNetCore.Mvc;
using MyShop.Entites.Repositers;

namespace MyShop.web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CustomerController : Controller
    {

        private readonly IUnitOfWork _unitofwork;


        public CustomerController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }
        public IActionResult Index()
        {
            var product = _unitofwork.Product.GetAll();

            return View(product);
        }



        public IActionResult Details(int id)
        {
            var product = _unitofwork.Product.GetFirstOrDefault(x => x.id == id, Includeword: "category");

            return View(product);
        }

    }
}
