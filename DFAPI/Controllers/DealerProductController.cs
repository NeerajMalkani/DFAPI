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
    public class DealerProductController : ControllerBase
    {
        private readonly DataContext _db;

        public DealerProductController(DataContext dbContext)
        {
            _db = dbContext;
        }

        #region Product
        [HttpGet]
        [Route("getproducts")]
        public Response GetProducts([FromQuery] DealerProductMapping dealerProductMapping)
        {
            Response response = new Response();
            try
            {
                List<DealerProduct> dealerProduct = new DealerProductRepository().GetProducts(_db, dealerProductMapping);
                if (dealerProduct.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, dealerProduct);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, dealerProduct);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertproduct")]
        public Response InsertProduct(DealerProductMapping dealerProductMapping)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new DealerProductRepository().InsertProduct(_db, dealerProductMapping);
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
        [Route("updateproduct")]
        public Response UpdateProduct(DealerProductMapping dealerProductMapping)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new DealerProductRepository().UpdateProduct(_db, dealerProductMapping);
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
