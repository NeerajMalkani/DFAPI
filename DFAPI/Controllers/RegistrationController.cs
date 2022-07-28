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

        #region Get Users
        [HttpGet]
        [Route("getusers")]
        public Response GetUsers()
        {
            Response response = new Response();
            try
            {
                List<UserCount> objUsers = new RegistrationRepository().GetUsers(_db);
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

        #region Insert User
        [HttpPost]
        [Route("insertuser")]
        public Response InsertUser(Users user)
        {
            Response response = new Response();
            try
            {
                int rowsAffected = new RegistrationRepository().InsertUser(_db, user);
                if (rowsAffected > 0)
                {
                    List<Users> users = new List<Users>();
                    users.Add(user);
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, users);
                }
                else if (rowsAffected == -2)
                {
                    Common.CreateResponse(HttpStatusCode.NotModified, "Error", "Name already exists", out response);
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
                List<LoginUser> objUsers = new RegistrationRepository().LoginUser(_db, users);
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

        #region Update User Role
        [HttpPost]
        [Route("updateuserrole")]
        public Response UpdateUserRole(Users user)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new RegistrationRepository().UpdateUserRole(_db, user);
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

        #region Update User Password
        [HttpPost]
        [Route("updateuserpassword")]
        public Response UpdateUserPassword(Users user)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new RegistrationRepository().UpdateUserPassword(_db, user);
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
