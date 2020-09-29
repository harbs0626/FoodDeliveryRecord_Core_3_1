using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryRecord_Core_3_1.Models
{
    public interface IReceiverRepository
    {
        IQueryable<Receiver> Receivers { get; }

    }
}
