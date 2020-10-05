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

                RecordViewModel recordViewModel = new RecordViewModel();
                recordViewModel.Receiver = new Receiver();
                recordViewModel.Receiver.RecordStatus = "New";
                recordViewModel.Receiver.Day = DateTime.Now.DayOfWeek.ToString();
                recordViewModel.Receiver.DeliveryDate = DateTime.Now.Date;

                return View("Record", recordViewModel);
            }
            else
            {
                ViewBag.Title = "Edit Record";

                RecordViewModel recordViewModel = new RecordViewModel();
                recordViewModel.Receiver = this._recordRepository.Receivers
                    .FirstOrDefault(r => r.Id == _recordId);

                return View("Record", recordViewModel);
            }
        }

        [HttpPost]
        public IActionResult Record(RecordViewModel _recordViewModel)
        {
            if (ModelState.IsValid)
            {
                //string _workflowStatus = "New";
                //_recordViewModel.Receiver.RecordStatus = _workflowStatus;

                this._recordRepository.SaveRecord(_recordViewModel);

                Debug.WriteLine("Done");

                TempData["SuccessResult"] = 
                    $"Successfully recorded {_recordViewModel.Receiver.RecordStatus} data.";

                return RedirectToAction("ViewRecords");
            }
            else
            {
                return View(_recordViewModel);
            }
        }
    }

}
