using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryRecord_Core_3_1.Models
{
    public class FoodCondition
    { 
        [Key]
        public int Id { get; set; }

        public string FoodType { get; set; }

        public bool PackageCondition { get; set; }

        public bool PackageTemperature { get; set; }

        public Detail Details { get; set; }

        public string ManagerSignature { get; set; }

        public string DateVerified { get; set; }

        public string AddedBy { get; set; }

        public string DateAdded { get; set; }
        
        public int ReceiverId { get; set; }
    }
}
