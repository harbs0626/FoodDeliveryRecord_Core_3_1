using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryRecord_Core_3_1.Models
{
    public class Detail
    {
        [Key]
        public int Id { get; set; }

        public string AdditionalDetail { get; set; }

        public string CorrectiveAction { get; set; }

        public int FoodConditionId { get; set; }

    }
}
