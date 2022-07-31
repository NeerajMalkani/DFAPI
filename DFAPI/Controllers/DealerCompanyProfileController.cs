using DFAPI.Entities;
using DFAPI.Helpers;
using DFAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerCompanyProfileController : ControllerBase
    {
        private readonly DataContext _db;

        public DealerCompanyProfileController(DataContext dbContext)
        {
            _db = dbContext;
        }

        #region My Services
        [HttpGet]
        [Route("getmyservices")]
        public Response GetDealerMyService([FromQuery] DealerServiceMapping dealerServiceMapping)
        {
            Response response = new Response();
            try
            {
                List<DealerServiceList> buyerCategoryMaster = new DealerCompanyProfileRepository().GetDealerMyService(_db, dealerServiceMapping);
                if (buyerCategoryMaster.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, buyerCategoryMaster);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, buyerCategoryMaster);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertmyservices")]
        public Response InsertMyServices(DealerServiceMapping dealerServiceMapping)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new DealerCompanyProfileRepository().InsertDealerMyService(_db, dealerServiceMapping);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
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

        [HttpPost]
        [Route("updatemyservices")]
        public Response UpdateMyServices(DealerServiceMapping dealerServiceMapping)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new DealerCompanyProfileRepository().UpdateDealerMyService(_db, dealerServiceMapping);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
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
    }
}
