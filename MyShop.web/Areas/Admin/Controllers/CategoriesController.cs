using Microsoft.AspNetCore.Mvc;
using MyShop.Entites.Models;
using MyShop.Entites.Repositers;

namespace MyShop.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitofwork;

        public CategoriesController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {

            return View();
        }


        public IActionResult GetData()
        {
            var categories = _unitofwork.Category.GetAll();
            return Json(new { data = categories }); //this method is releated to data table

        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _unitofwork.Category.GetFirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CreatedAdd")] Category category)
        {
            if (ModelState.IsValid)
            {

                _unitofwork.Category.Add(category);
                //_context.Add(category);
                //await _context.SaveChangesAsync();
                _unitofwork.Complete();
                TempData["create"] = "Item added sucssefully";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _unitofwork.Category.GetFirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreatedAdd")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitofwork.Category.UpdateCategory(category);
                    _unitofwork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["update"] = "Item Updated sucssefully";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _unitofwork.Category.GetFirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }


            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = _unitofwork.Category.GetFirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _unitofwork.Category.Remove(category);
                _unitofwork.Complete();
            }


            TempData["delete"] = "Item deleted sucssefully";
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _unitofwork.Category.GetFirstOrDefault(c => c.Id == id) != null;
        }
    }
}
