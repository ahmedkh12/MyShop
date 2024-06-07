using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.Entites.Repositers;
using MyShop.Entites.ViewModels;

namespace MyShop.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        private IWebHostEnvironment _webHostEnvironment; //for file upload 

        public ProductsController(IUnitOfWork unitofwork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofwork = unitofwork;
            _webHostEnvironment = webHostEnvironment;
        }





        public async Task<IActionResult> Index()
        {
            //var Categories = _unitofwork.Category.GetAll();
            //return View(Categories);
            return View();
        }


        public IActionResult GetData()
        {
            var products = _unitofwork.Product.GetAll(Includeword: "category");
            return Json(new { data = products }); //this method is releated to data table

        }



        [HttpGet]
        public IActionResult Create()
        {


            //for drop down list item
            ProductVM productVM = new ProductVM()
            {
                product = new Entites.Models.Product(),
                CategoryList = _unitofwork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            return View(productVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductVM productVM, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string root_path = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString();
                    var upload = Path.Combine(root_path, @"Images\Products");
                    var ext = Path.GetExtension(file.FileName);


                    using (var filestream = new FileStream(Path.Combine(upload, filename + ext), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    productVM.product.img = @"Images\Products\" + filename + ext;

                }
                _unitofwork.Product.Add(productVM.product);
                _unitofwork.Complete();
                TempData["create"] = "Item added sucssefully";
                return RedirectToAction(nameof(Index));
            }
            return View(productVM);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ProductVM productVM = new ProductVM()
            {
                product = _unitofwork.Product.GetFirstOrDefault(c => c.id == id),
                CategoryList = _unitofwork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };

            return View(productVM);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductVM productVM, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string root_path = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString();
                    var upload = Path.Combine(root_path, @"Images\Products");
                    var ext = Path.GetExtension(file.FileName);

                    if (productVM.product.img != null)
                    {
                        var oldimg = Path.Combine(root_path, productVM.product.img.TrimStart('\\'));
                        if (System.IO.File.Exists(oldimg))
                        {
                            System.IO.File.Delete(oldimg);
                        }
                    }
                    using (var filestream = new FileStream(Path.Combine(upload, filename + ext), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    productVM.product.img = @"Images\Products\" + filename + ext;

                }
                _unitofwork.Product.UpdateProduct(productVM.product);
                _unitofwork.Complete();
                TempData["update"] = "Item updated sucssefully";
                return RedirectToAction(nameof(Index));
            }
            return View(productVM);
        }




        [HttpDelete]
        public IActionResult DeleteProduct(int? id)
        {
            string root_path = _webHostEnvironment.WebRootPath;
            var productInDb = _unitofwork.Product.GetFirstOrDefault(x => x.id == id);
            if (productInDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            _unitofwork.Product.Remove(productInDb);
            var oldimg = Path.Combine(root_path, productInDb.img.TrimStart('\\'));
            if (System.IO.File.Exists(oldimg))
            {
                System.IO.File.Delete(oldimg);
            }
            _unitofwork.Complete();
            return Json(new { success = true, message = "product had been Deleted" });
        }




        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ProductVM productVM = new ProductVM()
            {
                product = _unitofwork.Product.GetFirstOrDefault(c => c.id == id),
                CategoryList = _unitofwork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };

            return View(productVM);
        }

    }
}






