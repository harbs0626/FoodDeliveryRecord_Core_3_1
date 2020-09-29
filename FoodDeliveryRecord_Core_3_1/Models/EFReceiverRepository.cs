using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryRecord_Core_3_1.Models
{
    public class EFReceiverRepository : IReceiverRepository
    {
        private ApplicationDbContext _context;

        public EFReceiverRepository(ApplicationDbContext _ctx)
        {
            this._context = _ctx;
        }

        public IQueryable<Receiver> Receivers =>
            this._context.Receivers;

    }
}
