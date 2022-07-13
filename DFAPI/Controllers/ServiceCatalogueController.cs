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
    public class ServiceCatalogueController : ControllerBase
    {
        private readonly DataContext _db;

        public ServiceCatalogueController(DataContext dbContext)
        {
            _db = dbContext;
        }

        #region Work Floor
        [HttpGet]
        [Route("getworkfloors")]
        public Response GetWorkFloors()
        {
            Response response = new Response();
            try
            {
                List<WorkFloorMaster> workFloorMaster = new ServiceCatalogueRepository().GetWorkFloors(_db);
                if (workFloorMaster.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, workFloorMaster);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, workFloorMaster);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertworkfloor")]
        public Response InsertWorkFloor(WorkFloorMaster workFloorMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().InsertWorkFloor(_db, workFloorMaster);
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

        [HttpPost]
        [Route("updateworkfloor")]
        public Response UpdateWorkFloor(WorkFloorMaster workFloorMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().UpdateWorkFloor(_db, workFloorMaster);
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

        [HttpDelete]
        [Route("deleteworkfloor")]
        public Response DeleteWorkFloor(WorkFloorMaster workFloorMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().DeleteWorkFloor(_db, workFloorMaster);
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

        #region Work Location
        [HttpGet]
        [Route("getworklocations")]
        public Response GetWorkLocations()
        {
            Response response = new Response();
            try
            {
                List<WorkLocationMaster> workLocationMaster = new ServiceCatalogueRepository().GetWorkLocations(_db);
                if (workLocationMaster.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, workLocationMaster);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, workLocationMaster);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertworklocation")]
        public Response InsertWorkLocation(WorkLocationMaster workLocationMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().InsertWorkLocation(_db, workLocationMaster);
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

        [HttpPost]
        [Route("updateworklocation")]
        public Response UpdateWorkLocation(WorkLocationMaster workLocationMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().UpdateWorkLocation(_db, workLocationMaster);
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

        [HttpDelete]
        [Route("deleteworklocation")]
        public Response DeleteWorkLocation(WorkLocationMaster workLocationMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().DeleteWorkLocation(_db, workLocationMaster);
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
