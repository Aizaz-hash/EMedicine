using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMedicineBackend.Models
{
    public class Response
    {
        public int statuscode { get; set; }
        public string statusMessage { get; set; }


        //users model
        public List<Users> listOfUsers { get; set; }
        public Users user { get; set; }

        //medicine model
        public List<Medicines> ListOfMedicines { get; set; }
        public Medicines medicines { get; set; }

        //Cart Model
        public List<Cart> listOfCart { get; set; }
        //public Cart card { get; set; }

        //order model
        public List<Order>  listOfOrders { get; set; }
        public Order order { get; set; }


        //orderItems model
        public List<OrderItems> listOfOrderItems { get; set; }
        public OrderItems orderItems { get; set; }



    }
}
