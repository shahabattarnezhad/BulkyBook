using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.Models;
using BulkyBook.Utilities;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new CoverType());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@CoverTypeName",coverType.CoverTypeName);
                _unitOfWork.SP_Call.Execute(SD.Proc_CoverType_Create, parameter);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(coverType);
        }

        public IActionResult Edit(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@CoverTypeId", id);
            var coverType = _unitOfWork.SP_Call.OneRecord<CoverType>(SD.Proc_CoverType_Get, parameter);

            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@CoverTypeId", coverType.CoverTypeId);
                parameter.Add("@CoverTypeName", coverType.CoverTypeName);

                if (coverType.CoverTypeId == id)
                {
                    _unitOfWork.SP_Call.Execute(SD.Proc_CoverType_Update,parameter);
                    _unitOfWork.Save();

                    return RedirectToAction(nameof(Index));
                }
            }

            return View(coverType);
        }


        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var value = _unitOfWork.SP_Call.List<CoverType>(SD.Proc_CoverType_GetAll, null);
            return Json(new { data = value });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@CoverTypeId",id);
            var coverType = _unitOfWork.SP_Call.OneRecord<CoverType>(SD.Proc_CoverType_Get,parameter);
            if (coverType == null)
            {
                return Json(new { success = false, message = "Error while deleting!" });
            }
            _unitOfWork.SP_Call.Execute(SD.Proc_CoverType_Delete,parameter);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful!" });
        }

        #endregion
    }
}
