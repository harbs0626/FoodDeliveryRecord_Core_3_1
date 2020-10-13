using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodDeliveryRecord_Core_3_1.Models;
using FoodDeliveryRecord_Core_3_1.Models.ViewModels;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryRecord_Core_3_1.Controllers
{
    public class HomeController : Controller
    {
        private IRecordRepository _recordRepository;

        public HomeController(IRecordRepository _recordRepo)
        {
            this._recordRepository = _recordRepo;
        }

        public ViewResult Index()
        {
            ViewBag.Title = "Dashboard";
            return View();
        }

        public ViewResult RecordList()
        {
            ViewBag.Title = "List of Record(s)";

            RecordViewModel _recordViewModel = new RecordViewModel();
            _recordViewModel.Receivers = this._recordRepository.Receivers
                .Include(vl => vl.VendorList)
                //.Include(fc => fc.FoodCondition)
                .Include(pc1 => pc1.FoodCondition.PackageCondition)
                .Include(pc2 => pc2.FoodCondition.ProductCondition)
                .Include(pt1 => pt1.FoodCondition.PackageTemperature)
                .Include(pt2 => pt2.FoodCondition.ProductTemperature)
                .OrderBy(r => r.Id);
            _recordViewModel.Vendors = this._recordRepository.Vendors
                .OrderBy(v => v.Id);

            return View(_recordViewModel);
        }

        public ViewResult Record(int _recordId)
        {
            RecordViewModel _recordViewModel = new RecordViewModel();

            if (_recordId == 0)
            {
                ViewBag.Title = "New Record";
                _recordViewModel.Receiver = new Receiver();
                _recordViewModel.Vendors = this._recordRepository.Vendors
                    .OrderBy(v => v.Id);
                return View("Record", _recordViewModel);
            }
            else
            {
                ViewBag.Title = "Edit Record";
                _recordViewModel.Receiver = this._recordRepository.Receivers
                    .Include(vl => vl.VendorList)
                    //.Include(fc => fc.FoodCondition)
                    .Include(pc1 => pc1.FoodCondition.PackageCondition)
                    .Include(pc2 => pc2.FoodCondition.ProductCondition)
                    .Include(pt1 => pt1.FoodCondition.PackageTemperature)
                    .Include(pt2 => pt2.FoodCondition.ProductTemperature)
                    .FirstOrDefault(r => r.Id == _recordId);
                _recordViewModel.Vendors = this._recordRepository.Vendors
                    .OrderBy(v => v.Id);

                return View("Record", _recordViewModel);
            }
        }

        [HttpPost]
        public IActionResult Record(RecordViewModel _recordViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_recordViewModel.Receiver.Id == 0)
                {
                    this._recordRepository.SaveRecord(_recordViewModel);

                    TempData["SuccessResult"] = 
                        $"Successfully recorded {_recordViewModel.Receiver.RecordStatus} data.";
                }
                else
                {
                    _recordViewModel.Receiver.RecordStatus = "Updated";

                    this._recordRepository.SaveRecord(_recordViewModel);

                    TempData["SuccessResult"] = $"Successfully updated data.";
                }

                return RedirectToAction("RecordList");
            }
            else
            {
                return View(_recordViewModel);
            }
        }

        public ViewResult Delete(int _recordId)
        {
            RecordViewModel _recordEntry = new RecordViewModel();

            ViewBag.Title = "List of Record(s)";

            try
            {
                this._recordRepository.DeleteRecord(_recordId);

                //Debug.WriteLine("Done...");

                TempData["SuccessResult"] = $"Successfully deleted data.";

                _recordEntry.Receivers = this._recordRepository.Receivers
                    .Include(vl => vl.VendorList)
                    //.Include(fc => fc.FoodCondition)
                    .Include(pc1 => pc1.FoodCondition.PackageCondition)
                    .Include(pc2 => pc2.FoodCondition.ProductCondition)
                    .Include(pt1 => pt1.FoodCondition.PackageTemperature)
                    .Include(pt2 => pt2.FoodCondition.ProductTemperature)
                    .OrderBy(item => item.Id);
                _recordEntry.Vendors = this._recordRepository.Vendors
                    .OrderBy(v => v.Id);

                return View("RecordList", _recordEntry);
            }
            catch(Exception ex)
            {
                ViewBag.Title = "View Records";

                return View("RecordList", _recordEntry);
            }
        }

    }

}
