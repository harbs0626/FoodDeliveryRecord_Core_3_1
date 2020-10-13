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

        public PackageCondition PackageCondition { get; set; }

        public ProductCondition ProductCondition { get; set; }

        public PackageTemperature PackageTemperature { get; set; }

        public ProductTemperature ProductTemperature { get; set; }

        public Detail Detail { get; set; }

    }
}
