using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryRecord_Core_3_1.Models.ViewModels
{
    public class RecordViewModel
    {
        public Receiver Receiver { get; set; }

        public Vendor Vendor { get; set; }

        public VendorList VendorList { get; set; }

        public FoodCondition FoodCondition { get; set; }

        public Detail Detail { get; set; }

        public IEnumerable<Receiver> Receivers { get; set; }

        public IEnumerable<Vendor> Vendors { get; set; }

        public IEnumerable<VendorList> VendorLists { get; set; }

        public IEnumerable<FoodCondition> FoodConditions { get; set; }

        public IEnumerable<Detail> Details { get; set; }

    }
}
