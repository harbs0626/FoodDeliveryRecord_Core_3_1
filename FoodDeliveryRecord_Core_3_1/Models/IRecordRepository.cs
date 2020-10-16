using FoodDeliveryRecord_Core_3_1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryRecord_Core_3_1.Models
{
    public interface IRecordRepository
    {
        IQueryable<Receiver> Receivers { get; }

        IQueryable<Vendor> Vendors { get; }

        IQueryable<VendorList> VendorLists { get; }

        IQueryable<FoodCondition> FoodConditions { get; }

        IQueryable<Detail> Details { get; }

        IQueryable<Signature> Signatures { get; }

        void SaveRecord(RecordViewModel _recordFormViewModel);

        void DeleteRecord(int _recordId);

        void ArchiveRecord(RecordViewModel _recordViewModel);

    }
}
