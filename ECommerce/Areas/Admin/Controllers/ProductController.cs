using ECommerce.Data.Repository.IRepository;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var products = unitOfWork.ProductRepository.GetAll(includeProperties: "Category");
            return View(products);
        }
        public IActionResult UpSert(int? id)
        {
            if (id != null && id != 0)
            {
                var product = unitOfWork.ProductRepository.GetAll(product => product.Id == id, includeProperties: "Category").FirstOrDefault();
                var vm = new ProductViewModel()
                {
                    Product = product,

                    CategoryList = unitOfWork.CategoryRepository.GetAll()
                    .Select(u => new SelectListItem
                    {
                        Value = u.Id.ToString(),
                        Text = u.CategoryName
                    })
                };
                vm.Product.CategoryId = product.CategoryId;
                return View(vm);
            }
            var viewModel = new ProductViewModel()
            {
                Product = new(),

                CategoryList = unitOfWork.CategoryRepository.GetAll()
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.CategoryName
                })
            };
            return View(viewModel);

        }

        [HttpPost]
        public IActionResult UpSert(ProductViewModel productViewModel) 
        {
            if (productViewModel.Product.Id != 0)
            {
                unitOfWork.ProductRepository.Update(productViewModel.Product);
            }
            else 
            {
                unitOfWork.ProductRepository.Add(productViewModel.Product);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index", "Product");
        }

    }
}
