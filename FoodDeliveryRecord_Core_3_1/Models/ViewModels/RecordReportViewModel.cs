using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryRecord_Core_3_1.Models.ViewModels
{
    public class RecordReportViewModel
    {
        public IEnumerable<Receiver> Receivers { get; set; }

        public IEnumerable<FoodCondition> FoodConditions { get; set; }

    }
}
