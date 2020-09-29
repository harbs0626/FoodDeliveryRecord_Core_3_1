using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodDeliveryRecord_Core_3_1.Models;
using FoodDeliveryRecord_Core_3_1.Models.ViewModels;
using System.Diagnostics;

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

        public ViewResult ViewRecords()
        {
            ViewBag.Title = "View Records";

            RecordReportViewModel _receiverViewModel = new RecordReportViewModel();
            _receiverViewModel.Receivers = this._recordRepository.Receivers
                .OrderBy(r => r.Id);

            return View(_receiverViewModel);
        }

        public ViewResult Record(int _recordId)
        {
            if (_recordId == 0)
            {
                ViewBag.Title = "New Record";
                return View("Record", new RecordViewModel());
            }
            else
            {
                ViewBag.Title = "Edit Record";
                return View("Record", this._recordRepository.Receivers
                    .FirstOrDefault(r => r.Id == _recordId));
            }
        }

        [HttpPost]
        public IActionResult Record(RecordViewModel _recordViewModel)
        {
            if (ModelState.IsValid)
            {
                string _workflowStatus = "New";

                this._recordRepository.SaveRecord(_recordViewModel, _workflowStatus);

                Debug.WriteLine("Done");

                return RedirectToAction("ViewRecords");
            }
            else
            {
                return View(_recordViewModel);
            }
        }
    }

}
