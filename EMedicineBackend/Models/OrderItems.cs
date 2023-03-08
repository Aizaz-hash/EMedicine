using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EMedicineBackend.Models
{
    public class OrderItems
    {
        public int id { get; set; }
        public decimal unitprice { get; set; }
        public decimal discount { get; set; }
        public decimal totalprice { get; set; }

        public int orderId { get; set; }

        public int medicineId { get; set; }
    }
}
