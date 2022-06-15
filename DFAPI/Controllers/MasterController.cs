using DFAPI.Entities;
using DFAPI.Helpers;
using DFAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly DataContext _db;

        public MasterController(DataContext dbContext)
        {
            _db = dbContext;
        }

        #region Activity Roles
        [HttpGet]
        [Route("getactivityroles")]
        public Response GetActivityRoles()
        {
            Response response = new Response();
            try
            {
                List<ActivityRoles> activityRoles = new MasterRepository().GetActivityRoles(_db);
                if (activityRoles.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, activityRoles);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, activityRoles);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }
        #endregion

        #region Services
        [HttpGet]
        [Route("getservices")]
        public Response GetServices()
        {
            Response response = new Response();
            try
            {
                List<Services> services = new MasterRepository().GetServices(_db);
                if (services.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, services);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, services);
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
