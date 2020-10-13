using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryRecord_Core_3_1.Models
{
    public class ProductTemperature
    {
        [Key]
        public int Id { get; set; }

        public bool Acceptable { get; set; } = false;

        public bool Unacceptable { get; set; } = false;

    }
}
