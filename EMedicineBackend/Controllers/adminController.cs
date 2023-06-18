using EMedicineBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;


namespace EMedicineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class adminController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public adminController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpPost]
        [Route("addUpdateMedicine")]

        public Response addUpdateMedicine(Medicines medicines)
        {
            Response response = new Response();
            DataAccessLayer DAL = new DataAccessLayer();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("dbConnection").ToString());
            response = DAL.addUpdateMedicine(medicines, connection);
            return response;
        }

        [HttpGet]
        [Route("userList")]

        public Response userList()
        {
            Response response = new Response();
            DataAccessLayer DAL = new DataAccessLayer();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("dbConnection").ToString());
            response = DAL.userList(connection);
            return response;

        }
    }
}
