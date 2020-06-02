using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new Company());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Company.Add(company);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(company);
        }

        public IActionResult Edit(int? id)
        {
            var company = _unitOfWork.Company.Get(id.GetValueOrDefault());
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == id)
                {
                    _unitOfWork.Company.Update(company);
                    _unitOfWork.Save();

                    return RedirectToAction(nameof(Index));
                }
            }

            return View(company);
        }


        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var value = _unitOfWork.Company.GetAll();
            return Json(new { data = value });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var company = _unitOfWork.Company.Get(id);
            if (company == null)
            {
                return Json(new { success = false, message = "Error while deleting!" });
            }
            _unitOfWork.Company.Remove(company);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful!" });
        }

        #endregion
    }
}
