using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryRecord_Core_3_1.Models
{
    public class Receiver
    {
        [Key]
        public int Id { get; set; }

        public string UnitName { get; set; }

        public int UnitNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public VendorList VendorList { get; set; }

        public string Day { get; set; } = DateTime.Now.DayOfWeek.ToString();

        public DateTime DeliveryDate { get; set; } = DateTime.Now.Date;

        public string DeliveryTime { get; set; }

        public string RecordStatus { get; set; } = "New";

        public FoodCondition FoodCondition { get; set; }

    }
}
