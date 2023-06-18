using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace EMedicineBackend.Models
{
    public class DataAccessLayer
    {

        //registration api 
        public Response register(Users users, SqlConnection connection)
        {

            Response response = new Response();
            SqlCommand command = new SqlCommand("sp_register" , connection) ;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@firstname", users.firstname);
            command.Parameters.AddWithValue("@lastname", users.lastname);
            command.Parameters.AddWithValue("@email", users.email);
            command.Parameters.AddWithValue("@password", users.password);
            command.Parameters.AddWithValue("@phone", users.phone);
            command.Parameters.AddWithValue("@dob", users.dob);
            command.Parameters.AddWithValue("@address", users.address);
            command.Parameters.AddWithValue("@fund", users.fund);
            command.Parameters.AddWithValue("@status", "pending");
            command.Parameters.AddWithValue("@typeOfUser", "user");

            connection.Open();

            int i = command.ExecuteNonQuery();
            connection.Close();

            if (i>0)
            {
                response.statuscode = 200;
                response.statusMessage = "User Registered Successfully !";
            }
            else
            {
                response.statuscode = 100;
                response.statusMessage = "User Registration Failed !!";
            }


            return response;
        }

        //login api 

        public Response login(Users users, SqlConnection connection)
        {

            Response response = new Response();
            SqlDataAdapter adp  = new SqlDataAdapter("sp_login" , connection);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@email", users.email);
            adp.SelectCommand.Parameters.AddWithValue("@password", users.password);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            

            if (dt.Rows.Count > 0)
            {
                users.id = Convert.ToInt32(dt.Rows[0]["id"]);
                users.firstname = Convert.ToString(dt.Rows[0]["firstname"]);
                users.lastname = Convert.ToString(dt.Rows[0]["lastname"]);
                users.email = Convert.ToString(dt.Rows[0]["email"]);
                users.typeOfUser = Convert.ToInt32(dt.Rows[0]["typeOfUser"]);

                response.statuscode = 200;
                response.statusMessage = "user is valid";
                response.user = users;
            }

            else
            {
                response.statuscode = 100;
                response.statusMessage = "user is invalid";
                response.user = null;

            }

            return response;
        }

        //view user api 
        public Response viewUser(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter adp = new SqlDataAdapter("sp_viewUser", connection);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@id", users.id);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                users.id = Convert.ToInt32(dt.Rows[0]["id"]); 
                users.firstname = Convert.ToString(dt.Rows[0]["firstname"]);
                users.lastname = Convert.ToString(dt.Rows[0]["lastname"]);
                users.email = Convert.ToString(dt.Rows[0]["email"]);
                users.password = Convert.ToString(dt.Rows[0]["password"]);
                users.typeOfUser = Convert.ToInt32(dt.Rows[0]["typeOfUser"]);
                users.fund = Convert.ToDecimal(dt.Rows[0]["fund"]);
                users.createdOn = Convert.ToDateTime(dt.Rows[0]["createdOn"]);
                users.typeOfUser = Convert.ToInt32(dt.Rows[0]["typeOfUser"]);
                users.dob = Convert.ToDateTime(dt.Rows[0]["dob"]);

                response.statuscode = 200;
                response.statusMessage = "user exist";
                response.user = users;
            }

            else
            {
                response.statuscode = 100;
                response.statusMessage = "user doesnot exist";
                response.user = null;

            }
            return response;
        }

        //update user profile api 
        public Response updateProfile(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_updateProfile", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@firstname", users.firstname);
            cmd.Parameters.AddWithValue("@lastname", users.lastname);
            cmd.Parameters.AddWithValue("@password", users.password);
            cmd.Parameters.AddWithValue("@email", users.email);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i == 0)
            {
                response.statuscode = 200;
                response.statusMessage = "user profile updated successfully";
            }


            else
            {
                response.statuscode = 100;
                response.statusMessage = "cannot update user profile !";

            }
            return response;
        }

        //cart management  api 
        public Response cartManagement(Cart cart, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_cartManagement", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", cart.id);
            cmd.Parameters.AddWithValue("@unitprice", cart.unitprice);
            cmd.Parameters.AddWithValue("@discount", cart.discount);
            cmd.Parameters.AddWithValue("@quantity", cart.quantity);
            cmd.Parameters.AddWithValue("@totalprice", cart.totalprice);
            cmd.Parameters.AddWithValue("@medicineId", cart.medicineId);


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i == 0)
            {
                response.statuscode = 200;
                response.statusMessage = "item added successfully";
            }


            else
            {
                response.statuscode = 100;
                response.statusMessage = "cannot add item into cart!";

            }
            return response;
        }

        public Response placeanOrder(Users users , SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_palceanOrder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", users.id);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i == 0)
            {
                response.statuscode = 200;
                response.statusMessage = "order place successfully";
            }


            else
            {
                response.statuscode = 100;
                response.statusMessage = "order could not be placed !";

            }
            return response;
        }


        public Response userOrderList(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter adp = new SqlDataAdapter("userOrderList", connection);
            List<Order> lisOforders = new List<Order>();
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@typeOfUser", users.typeOfUser);
            adp.SelectCommand.Parameters.AddWithValue("@id", users.id);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Order order = new Order();
                    order.id=  Convert.ToInt32(dt.Rows[0]["id"]);
                    order.orderno = Convert.ToString(dt.Rows[0]["orderno"]);
                    order.ordertotal = Convert.ToDecimal(dt.Rows[0]["ordertotal"]);
                    order.status = Convert.ToInt32(dt.Rows[0]["ordertotal"]);

                    lisOforders.Add(order);
                }

                if(lisOforders.Count > 0)
                {
                    response.statuscode = 200;
                    response.statusMessage = "order details avaliable";
                    response.listOfOrders = lisOforders;
                }

                else
                {
                    response.statuscode = 100;
                    response.statusMessage = "order details not avaliable ";
                    response.listOfOrders = null;

                }

            }

            else
            {
                response.statuscode = 100;
                response.statusMessage = "order details not avaliable ";
                response.listOfOrders = null;

            }


            return response;
        }

        public Response addUpdateMedicine (Medicines medicines , SqlConnection connection)
        {
            Response response = new Response();

            SqlCommand cmd = new SqlCommand("sp_addUpdateMedicine" , connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", medicines.name);
            cmd.Parameters.AddWithValue("@manufacturer", medicines.manufacturer);
            cmd.Parameters.AddWithValue("@unitprice", medicines.unitprice);
            cmd.Parameters.AddWithValue("@discount", medicines.discount);
            cmd.Parameters.AddWithValue("@quantity", medicines.quantity);
            cmd.Parameters.AddWithValue("@expirydate", medicines.expirydate);
            cmd.Parameters.AddWithValue("@imageurl", medicines.imageurl);
            cmd.Parameters.AddWithValue("@status", medicines.status);
            cmd.Parameters.AddWithValue("@type", medicines.type);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.statuscode = 200;
                response.statusMessage = "medicine inserted successfully ";
            }

            else
            {
                response.statuscode = 100;
                response.statusMessage = "medicine cannot be inserted ! ";
            }

            return response;

        }

        public Response userList(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter adp = new SqlDataAdapter("userList", connection);
            List<Users> lisOfUSers = new List<Users>();
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Users users = new Users();
                    users.id = Convert.ToInt32(dt.Rows[0]["id"]);
                    users.firstname = Convert.ToString(dt.Rows[0]["firstname"]);
                    users.lastname = Convert.ToString(dt.Rows[0]["lastname"]);
                    users.password = Convert.ToString(dt.Rows[0]["password"]);
                    users.email = Convert.ToString(dt.Rows[0]["email"]);
                    users.fund = Convert.ToDecimal(dt.Rows[0]["fund"]);
                    users.createdOn = Convert.ToDateTime(dt.Rows[0]["createdOn"]);
                    users.status = Convert.ToInt32(dt.Rows[0]["ordertotal"]);

                    lisOfUSers.Add(users);
                }

                if (lisOfUSers.Count > 0)
                {
                    response.statuscode = 200;
                    response.statusMessage = "user detailes fetched";
                    response.listOfUsers = lisOfUSers;
                }

                else
                {
                    response.statuscode = 100;
                    response.statusMessage = "user details not avaliable ";
                    response.listOfUsers = null;

                }

            }

            else
            {
                response.statuscode = 100;
                response.statusMessage = "user details not avaliable ";
                response.listOfOrders = null;

            }


            return response;
        }

    }
}
