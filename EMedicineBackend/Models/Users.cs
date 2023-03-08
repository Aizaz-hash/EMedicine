using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMedicineBackend.Models
{
    public class Users
    {

        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int phone { get; set; }

        public DateTime dob { get; set; }
        public string  address { get; set; }
        public decimal fund { get; set; }

        public int typeOfUser { get; set; }
        public int status { get; set; }

        public DateTime createdOn { get; set; }



    }
}
