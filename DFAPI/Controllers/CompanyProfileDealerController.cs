using DFAPI.Entities;
using DFAPI.Helpers;
using DFAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyProfileDealerController : ControllerBase
    {
        private readonly DataContext _db;

        public CompanyProfileDealerController(DataContext dbContext)
        {
            _db = dbContext;
        }

        #region Company Profile Dealers
        [HttpGet]
        [Route("getmyservices")]
        public Response GetDealerMyService([FromQuery] DealerServiceMapping dealerServiceMapping)
        {
            Response response = new Response();
            try
            {
                List<DealerServiceList> buyerCategoryMaster = new CompanyProfileDealerRepository().GetDealerMyService(_db, dealerServiceMapping);
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
                long rowsAffected = new CompanyProfileDealerRepository().InsertDealerMyService(_db, dealerServiceMapping);
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
                long rowsAffected = new CompanyProfileDealerRepository().UpdateDealerMyService(_db, dealerServiceMapping);
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

        #region Buyer Category
        [HttpGet]
        [Route("getbuyercategory")]
        public Response GetBuyerCategory()
        {
            Response response = new Response();
            try
            {
                List<BuyerCategoryMaster> buyerCategoryMaster = new CompanyProfileDealerRepository().GetBuyerCategory(_db);
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
        [Route("insertbuyercategory")]
        public Response InsertBuyerCategory(BuyerCategoryMaster buyerCategoryMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new CompanyProfileDealerRepository().InsertBuyerCategory(_db, buyerCategoryMaster);
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
        [Route("updatebuyercategory")]
        public Response UpdateBuyerCategory(BuyerCategoryMaster buyerCategoryMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new CompanyProfileDealerRepository().UpdateBuyerCategory(_db, buyerCategoryMaster);
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

        [HttpDelete]
        [Route("deletebuyercategory")]
        public Response DeleteBuyerCategory(BuyerCategoryMaster buyerCategoryMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new CompanyProfileDealerRepository().DeleteBuyerCategory(_db, buyerCategoryMaster);
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
