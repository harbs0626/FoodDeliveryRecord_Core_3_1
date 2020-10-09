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

        public IQueryable<Receiver> Receivers 
            => this._context.Receivers;

        public IQueryable<Vendor> Vendors
            => this._context.Vendors;

        public IQueryable<VendorList> VendorLists
            => this._context.VendorLists;

        //public IQueryable<FoodCondition> FoodConditions 
        //    => this._context.FoodConditions;

        //public IQueryable<Signature> Signatures 
        //    => this._context.Signatures;

        public void SaveRecord(RecordViewModel _recordViewModel)
        {
            if (_recordViewModel.Receiver.Id == 0)
            {
                //_recordViewModel.Receiver.VendorList = _recordViewModel.VendorList;
                this._context.Receivers.Add(_recordViewModel.Receiver);
                this._context.VendorLists.Add(_recordViewModel.Receiver.VendorList);
            }
            else
            {
                RecordViewModel _recordEntry = new RecordViewModel();
                _recordEntry.Receiver = this._context.Receivers
                    .Include(vl => vl.VendorList)
                    .FirstOrDefault(item => item.Id == _recordViewModel.Receiver.Id);

                _recordEntry.VendorList = this._context.VendorLists
                    .FirstOrDefault(item => item.Id == _recordEntry.Receiver.VendorList.Id);

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
                }
            }

            this._context.SaveChanges();
        }

        public void DeleteRecord(int _recordId)
        {
            RecordViewModel _recordEntry = new RecordViewModel();
            _recordEntry.Receiver = this._context.Receivers
                .FirstOrDefault(item => item.Id == _recordId);

            if (_recordEntry != null)
            {
                this._context.Receivers.Remove(_recordEntry.Receiver);
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
