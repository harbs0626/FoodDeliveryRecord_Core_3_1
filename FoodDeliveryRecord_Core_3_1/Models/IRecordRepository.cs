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

        //IQueryable<FoodCondition> FoodConditions { get; set; }

        //IQueryable<Signature> Signatures { get; set; }

        void SaveRecord(RecordViewModel _recordFormViewModel);

        void DeleteRecord(RecordViewModel _recordViewModel);

        void ArchiveRecord(RecordViewModel _recordViewModel);

    }
}
