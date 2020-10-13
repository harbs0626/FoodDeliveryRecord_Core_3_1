using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryRecord_Core_3_1.Models
{
    public class Record
    {
        public Receiver Receiver { get; set; }

        public FoodCondition FoodCondition { get; set; }

        public Detail Detail { get; set; }

        public Signature Signature { get; set; }

    }
}
