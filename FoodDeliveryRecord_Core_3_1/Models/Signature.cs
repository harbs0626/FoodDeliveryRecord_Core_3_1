﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryRecord_Core_3_1.Models
{
    public class Signature
    {
        [Key]
        public int Id { get; set; }

        public string ManagerSignature { get; set; }

        public DateTime? DateVerified { get; set; }

    }
}
