using DFAPI.Entities;
using DFAPI.Helpers;
using DFAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly DataContext _db;

        public RegistrationController(DataContext dbContext)
        {
            _db = dbContext;
        }

        #region Insert User
        [HttpPost]
        [Route("insertuser")]
        public Response InsertUser(Users user)
        {
            Response response = new Response();
            try
            {
                List<Users> users = new RegistrationRepository().InsertUser(_db, user);
                if (users != null)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, users);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }
        #endregion

        #region Login User
        [HttpGet]
        [Route("login")]
        public Response LoginUser([FromQuery]Users users)
        {
            Response response = new Response();
            try
            {
                List<Users> objUsers = new RegistrationRepository().LoginUser(_db, users);
                if (objUsers.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, objUsers);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }
        #endregion

        #region Update User
        [HttpPost]
        [Route("updateuser")]
        public Response UpdateUser(Users user)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new RegistrationRepository().UpdateUser(_db, user);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }
        #endregion
    }
}
