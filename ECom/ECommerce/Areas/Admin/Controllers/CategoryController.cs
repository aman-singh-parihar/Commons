using ECommerce.Data;
using ECommerce.Data.Repository.IRepository;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.Save();
            TempData["success"] = "Category created successfully.";
            return RedirectToAction("Index", "Category");
        }
        public IActionResult Edit(int? id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.Save();
            TempData["success"] = "Category updated successfully.";
            return RedirectToAction("Index", "Category");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);
            _unitOfWork.CategoryRepository.Delete(category);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully.";
            return RedirectToAction("Index", "Category");
        }

        [ActionName("Delete")]
        public IActionResult DeleteView(int? id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);
            return View(category);
        }


    }
}
