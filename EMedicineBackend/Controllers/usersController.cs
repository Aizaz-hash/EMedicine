using EMedicineBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
//using Npgsql;

namespace EMedicineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {


        private readonly IConfiguration _configuration;

        public usersController(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }


        [HttpPost]
        [Route("registration")]
        public Response register(Users users)
        {
            Response response = new Response();
            DataAccessLayer DAL     = new DataAccessLayer();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("dbConnection").ToString());
            response = DAL.register(users , connection); 
            return response;


        }

        [HttpPost]
        [Route("login")]
        public Response login(Users users)
        {
            Response response = new Response();
            DataAccessLayer DAL = new DataAccessLayer();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("dbConnection").ToString());
            response = DAL.login(users, connection);
            return response;


        }


        [HttpPost]
        [Route("viewUser")]
        public Response viewUser(Users users)
        {
            Response response = new Response();
            DataAccessLayer DAL = new DataAccessLayer();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("dbConnection").ToString());
            response = DAL.viewUser(users, connection);
            return response;


        }


        [HttpPost]
        [Route("updateProfile")]
        public Response updateProfile(Users users)
        {
            Response response = new Response();
            DataAccessLayer DAL = new DataAccessLayer();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("dbConnection").ToString());
            response = DAL.updateProfile(users, connection);
            return response;


        }




    }
}
