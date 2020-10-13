using FoodDeliveryRecord_Core_3_1.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryRecord_Core_3_1.Models
{
    public class EFRecordRepository : IRecordRepository
    {
        private ApplicationDbContext _context;

        public EFRecordRepository(ApplicationDbContext _ctx)
        {
            this._context = _ctx;
        }

        public IQueryable<Receiver> Receivers => this._context.Receivers;
        public IQueryable<Vendor> Vendors => this._context.Vendors;
        public IQueryable<VendorList> VendorLists => this._context.VendorLists;
        public IQueryable<FoodCondition> FoodConditions => this._context.FoodConditions;
        public IQueryable<Detail> Details => this._context.Details;

        //public IQueryable<Signature> Signatures 
        //    => this._context.Signatures;

        public void SaveRecord(RecordViewModel _recordViewModel)
        {
            if (_recordViewModel.Receiver.Id == 0)
            {
                this._context.Receivers.Add(_recordViewModel.Receiver);
                this._context.VendorLists.Add(_recordViewModel.Receiver.VendorList);
                this._context.FoodConditions.Add(_recordViewModel.Receiver.FoodCondition);
                this._context.Details.Add(_recordViewModel.Receiver.FoodCondition.Detail);
            }
            else
            {
                RecordViewModel _recordEntry = new RecordViewModel();
                _recordEntry.Receiver = this._context.Receivers
                    .Include(vl => vl.VendorList)
                    //.Include(fc => fc.FoodCondition)
                    .Include(pc1 => pc1.FoodCondition.PackageCondition)
                    .Include(pc2 => pc2.FoodCondition.ProductCondition)
                    .Include(pt1 => pt1.FoodCondition.PackageTemperature)
                    .Include(pt2 => pt2.FoodCondition.ProductTemperature)
                    .Include(d => d.FoodCondition.Detail)
                    .FirstOrDefault(item => item.Id == _recordViewModel.Receiver.Id);

                _recordEntry.VendorList = this._context.VendorLists
                    .FirstOrDefault(item => item.Id == _recordEntry.Receiver.VendorList.Id);

                _recordEntry.FoodCondition = this._context.FoodConditions
                    .FirstOrDefault(item => item.Id == _recordEntry.Receiver.FoodCondition.Id);

                if (_recordEntry != null)
                {
                    _recordEntry.Receiver.UnitName = _recordViewModel.Receiver.UnitName;
                    _recordEntry.Receiver.UnitNumber = _recordViewModel.Receiver.UnitNumber;
                    _recordEntry.Receiver.FirstName = _recordViewModel.Receiver.FirstName;
                    _recordEntry.Receiver.LastName = _recordViewModel.Receiver.LastName;
                    _recordEntry.Receiver.Day = _recordViewModel.Receiver.Day;
                    _recordEntry.Receiver.DeliveryDate = _recordViewModel.Receiver.DeliveryDate;
                    _recordEntry.Receiver.DeliveryTime = _recordViewModel.Receiver.DeliveryTime;
                    _recordEntry.Receiver.RecordStatus = _recordViewModel.Receiver.RecordStatus;

                    _recordEntry.VendorList.Vendors = _recordViewModel.Receiver.VendorList.Vendors;

                    _recordEntry.FoodCondition.PackageCondition.Acceptable = 
                        _recordViewModel.Receiver.FoodCondition.PackageCondition.Acceptable;
                    _recordEntry.FoodCondition.PackageCondition.Unacceptable = 
                        _recordViewModel.Receiver.FoodCondition.PackageCondition.Unacceptable;
                    _recordEntry.FoodCondition.ProductCondition.Acceptable = 
                        _recordViewModel.Receiver.FoodCondition.ProductCondition.Acceptable;
                    _recordEntry.FoodCondition.ProductCondition.Unacceptable = 
                        _recordViewModel.Receiver.FoodCondition.ProductCondition.Unacceptable;

                    _recordEntry.FoodCondition.PackageTemperature.Acceptable = 
                        _recordViewModel.Receiver.FoodCondition.PackageTemperature.Acceptable;
                    _recordEntry.FoodCondition.PackageTemperature.Unacceptable = 
                        _recordViewModel.Receiver.FoodCondition.PackageTemperature.Unacceptable;
                    _recordEntry.FoodCondition.ProductTemperature.Acceptable = 
                        _recordViewModel.Receiver.FoodCondition.ProductTemperature.Acceptable;
                    _recordEntry.FoodCondition.ProductTemperature.Unacceptable = 
                        _recordViewModel.Receiver.FoodCondition.ProductTemperature.Unacceptable;

                    _recordEntry.FoodCondition.Detail.AdditionalDetail = 
                        _recordViewModel.Receiver.FoodCondition.Detail.AdditionalDetail;
                    _recordEntry.FoodCondition.Detail.CorrectiveAction =
                        _recordViewModel.Receiver.FoodCondition.Detail.CorrectiveAction;
                }
            }

            this._context.SaveChanges();
        }

        public void DeleteRecord(int _recordId)
        {
            RecordViewModel _recordEntry = new RecordViewModel();
            _recordEntry.Receiver = this._context.Receivers
                .Include(vl => vl.VendorList)
                //.Include(fc => fc.FoodCondition)
                .Include(pc1 => pc1.FoodCondition.PackageCondition)
                .Include(pc2 => pc2.FoodCondition.ProductCondition)
                .Include(pt1 => pt1.FoodCondition.PackageTemperature)
                .Include(pt2 => pt2.FoodCondition.ProductTemperature)
                .Include(d => d.FoodCondition.Detail)
                .FirstOrDefault(item => item.Id == _recordId);

            _recordEntry.VendorList = this._context.VendorLists
                    .FirstOrDefault(item => item.Id == _recordEntry.Receiver.VendorList.Id);

            _recordEntry.FoodCondition = this._context.FoodConditions
                    .FirstOrDefault(item => item.Id == _recordEntry.Receiver.FoodCondition.Id);

            if (_recordEntry != null)
            {
                this._context.Receivers.Remove(_recordEntry.Receiver);
                this._context.VendorLists.Remove(_recordEntry.VendorList);
                this._context.FoodConditions.Remove(_recordEntry.FoodCondition);
                this._context.Details.Remove(_recordEntry.FoodCondition.Detail);
                this._context.SaveChanges();
            }
        }

        public void ArchiveRecord(RecordViewModel _recordViewModel)
        {
            //RecordViewModel _recordEntry = new RecordViewModel();
            //_recordEntry.Receiver = this._context.Receivers
            //    .FirstOrDefault(item => item.Id == _recordViewModel.Receiver.Id);

            //if (_recordEntry != null)
            //{
            //    _recordEntry.Receiver.RecordStatus = "Archived";
            //}

            //this._context.SaveChanges();
        }
    }
}
