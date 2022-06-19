using DFAPI.Entities;
using DFAPI.Helpers;
using DFAPI.Repositories;
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
                List<ActivityMaster> activityRoles = new MasterRepository().GetActivityRoles(_db);
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

        [HttpPost]
        [Route("insertactivityroles")]
        public Response InsertActivityRoles(ActivityMaster activityMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().InsertActivityRoles(_db, activityMaster);
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
        [Route("updateactivityroles")]
        public Response UpdateActivityRoles(ActivityMaster activityMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().UpdateActivityRoles(_db, activityMaster);
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
        [Route("deleteactivityroles")]
        public Response DeleteActivityRoles(ActivityMaster activityMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().DeleteActivityRoles(_db, activityMaster);
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

        #region Services
        [HttpGet]
        [Route("getservices")]
        public Response GetServices()
        {
            Response response = new Response();
            try
            {
                List<ServiceMaster> services = new MasterRepository().GetServices(_db);
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

        [HttpPost]
        [Route("insertservices")]
        public Response InsertServices(ServiceMaster serviceMasters)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().InsertServices(_db, serviceMasters);
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
        [Route("updateservices")]
        public Response UpdateServices(ServiceMaster serviceMasters)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().UpdateServices(_db, serviceMasters);
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
        [Route("deleteservices")]
        public Response DeleteServices(ServiceMaster serviceMasters)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().DeleteServices(_db, serviceMasters);
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

        #region Unit Of Sales
        [HttpGet]
        [Route("getunitofsales")]
        public Response GetUnitOfSales()
        {
            Response response = new Response();
            try
            {
                List<UnitOfSalesMaster> unitOfSales = new MasterRepository().GetUnitOfSales(_db);
                if (unitOfSales.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, unitOfSales);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, unitOfSales);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertunitofsales")]
        public Response InsertUnitOfSales(UnitOfSalesMaster unitOfSalesMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().InsertUnitOfSales(_db, unitOfSalesMaster);
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
        [Route("updateunitofsales")]
        public Response UpdateUnitOfSales(UnitOfSalesMaster unitOfSalesMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().UpdateUnitOfSales(_db, unitOfSalesMaster);
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
        [Route("deleteunitofsales")]
        public Response DeleteUnitOfSales(UnitOfSalesMaster unitOfSalesMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().DeleteUnitOfSales(_db, unitOfSalesMaster);
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

        #region Category
        [HttpGet]
        [Route("getcategory")]
        public Response GetCategories()
        {
            Response response = new Response();
            try
            {
                List<CategoryMaster> categoryMasters = new MasterRepository().GetCategories(_db);
                if (categoryMasters.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, categoryMasters);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, categoryMasters);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertcategory")]
        public Response InsertCategory(CategoryMaster categoryMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().InsertCategory(_db, categoryMaster);
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
        [Route("updatecategory")]
        public Response UpdateCategory(CategoryMaster categoryMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().UpdateCategory(_db, categoryMaster);
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
        [Route("deletecategory")]
        public Response DeleteCategory(CategoryMaster categoryMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().DeleteCategory(_db, categoryMaster);
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
