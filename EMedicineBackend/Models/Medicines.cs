using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EMedicineBackend.Models
{
    public class Medicines
    {
        public int id { get; set; }
        public string name { get; set; }

        public string manufacturer { get; set; }

        public decimal unitprice { get; set; }
        public decimal discount { get; set; }

        public int quantity { get; set; }
        public DateTime expirydate  { get; set; }

        public string imageurl  { get; set; }

        public int status { get; set; }

        public string type { get; set; }



    }
}
