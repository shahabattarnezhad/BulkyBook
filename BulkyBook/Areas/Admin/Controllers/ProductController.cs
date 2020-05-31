using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ProductVM productVm = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                }),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.CoverTypeName,
                    Value = i.CoverTypeId.ToString()
                })
            };
            return View(productVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductVM productVm)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\products");
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    productVm.Product.ProductImage = @"\images\products" + fileName + extension;
                }

                _unitOfWork.Product.Add(productVm.Product);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(productVm);
        }

        public IActionResult Edit(int? id)
        {
            ProductVM productVm = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                }),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.CoverTypeName,
                    Value = i.CoverTypeId.ToString()
                })
            };

            productVm.Product = _unitOfWork.Product.Get(id.GetValueOrDefault());
            if (productVm.Product == null)
            {
                return NotFound();
            }
            return View(productVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, ProductVM productVm)
        {
            if (ModelState.IsValid)
            {
                if (productVm.Product.ProductId == id)
                {
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    var files = HttpContext.Request.Form.Files;

                    if (files.Count > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(webRootPath, @"images\products");
                        var extension = Path.GetExtension(files[0].FileName);

                        if (productVm.Product.ProductImage != null)
                        {
                            var imagePath = Path.Combine(webRootPath, productVm.Product.ProductImage.TrimStart('\\'));
                            if (System.IO.File.Exists(imagePath))
                            {
                                System.IO.File.Delete(imagePath);
                            }
                        }

                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        productVm.Product.ProductImage = @"\images\products" + fileName + extension;
                    }
                    else
                    {
                        // When they do not change the image!
                        if (productVm.Product.ProductId != 0)
                        {
                            Product objFromDb = _unitOfWork.Product.Get(productVm.Product.ProductId);
                            productVm.Product.ProductImage = objFromDb.ProductImage;
                        }
                    }
                    _unitOfWork.Product.Update(productVm.Product);
                    _unitOfWork.Save();

                    return RedirectToAction(nameof(Index));
                }
            }

            return View(productVm);
        }


        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var value = _unitOfWork.Product.GetAll(includeProperties: "Category,CoverType");
            return Json(new { data = value });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.Product.Get(id);
            if (product == null)
            {
                return Json(new { success = false, message = "Error while deleting!" });
            }
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful!" });
        }

        #endregion
    }
}
