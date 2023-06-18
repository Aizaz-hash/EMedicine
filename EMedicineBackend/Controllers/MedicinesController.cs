using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EMedicineBackend.Models;
using Microsoft.Data.SqlClient;


namespace EMedicineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MedicinesController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpPost]
        [Route("cartManagement")]
        public Response cartManagement(Cart cart)
        {
            Response response = new Response();
            DataAccessLayer DAL = new DataAccessLayer();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("dbConnection").ToString());
            response = DAL.cartManagement(cart, connection);
            return response;
        }

        [HttpPost]
        [Route("placeanOrder")]
        public Response placeanOrder(Users users)
        {
            Response response = new Response();
            DataAccessLayer DAL = new DataAccessLayer();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("dbConnection").ToString());
            response = DAL.placeanOrder(users, connection);
            return response;
        }


        [HttpPost]
        [Route("userOrderList")]
        public Response userOrderList(Users users)
        {
            Response response = new Response();
            DataAccessLayer DAL = new DataAccessLayer();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("dbConnection").ToString());
            response = DAL.userOrderList(users, connection);
            return response;
        }

    }
}
