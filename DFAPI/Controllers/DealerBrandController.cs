using DFAPI.Entities;
using DFAPI.Helpers;
using DFAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerBrandController : ControllerBase
    {
        private readonly DataContext _db;

        public DealerBrandController(DataContext dbContext)
        {
            _db = dbContext;
        }

        #region Brand Master
        [HttpGet]
        [Route("getbrand")]
        public Response GetBrand([FromQuery] BrandMaster brandMasterParam)
        {
            Response response = new Response();
            try
            {
                List<BrandMaster> brandMaster = new DealerBrandRepository().GetBrand(_db, brandMasterParam);
                if (brandMaster.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, brandMaster);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, brandMaster);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertbrand")]
        public Response InsertBrand(BrandMaster brandMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new DealerBrandRepository().InsertBrand(_db, brandMaster);
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
        [Route("updatebrand")]
        public Response UpdateBrand(BrandMaster brandMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new DealerBrandRepository().UpdateBrand(_db, brandMaster);
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
        public Response DeleteBrand(BrandMaster brandMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new DealerBrandRepository().DeleteBrand(_db, brandMaster);
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

        #region Brand Setup
        [HttpGet]
        [Route("getbrandsetup")]
        public Response GetBrandSetup([FromQuery] DealerBrands dealerBrands)
        {
            Response response = new Response();
            try
            {
                List<DealerBrandResponse> dealerBrandResponse = new DealerBrandRepository().GetBrandSetup(_db, dealerBrands);
                if (dealerBrandResponse.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, dealerBrandResponse);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, dealerBrandResponse);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertbrandsetup")]
        public Response InsertBrandSetup(DealerBrands dealerBrands)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new DealerBrandRepository().InsertBrandSetup(_db, dealerBrands);
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
        [Route("updatebrandsetup")]
        public Response UpdateBrandSetup(DealerBrands dealerBrands)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new DealerBrandRepository().UpdateBrandSetup(_db, dealerBrands);
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
        public Response GetBuyerCategory([FromQuery] BuyerCategoryMaster buyerCategoryMasterParam)
        {
            Response response = new Response();
            try
            {
                List<BuyerCategoryMaster> buyerCategoryMaster = new DealerBrandRepository().GetBuyerCategory(_db, buyerCategoryMasterParam);
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
                long rowsAffected = new DealerBrandRepository().InsertBuyerCategory(_db, buyerCategoryMaster);
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
                long rowsAffected = new DealerBrandRepository().UpdateBuyerCategory(_db, buyerCategoryMaster);
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
                long rowsAffected = new DealerBrandRepository().DeleteBuyerCategory(_db, buyerCategoryMaster);
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
