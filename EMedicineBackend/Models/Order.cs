using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EMedicineBackend.Models
{
    public class Order
    {
        public int id { get; set; }

        public decimal ordertotal  { get; set; }

        public int status { get; set; }

        public int userId { get; set; }
        public string orderno { get; set; }

    }
}
