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
    public class GeneralUserEnquiryEstimationsController : ControllerBase
    {
        private readonly DataContext _db;

        public GeneralUserEnquiryEstimationsController(DataContext dbContext)
        {
            _db = dbContext;
        }

        #region Image Gallery
        [HttpGet]
        [Route("getimagegallery")]
        public Response GetImageGallery()
        {
            Response response = new Response();
            try
            {
                List<ImageGallery> imageGalleries = new GeneralUserEnquiryEstimationsRepository().GetImageGallery(_db);
                if (imageGalleries.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, imageGalleries);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, imageGalleries);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getimagegallerybycategoryid")]
        public Response GetImageGallery([FromQuery] ImageGalleryRequest imageGalleryRequest)
        {
            Response response = new Response();
            try
            {
                List<ImageGallery> imageGalleries = new GeneralUserEnquiryEstimationsRepository().GetImageGalleryByCategoryID(_db, imageGalleryRequest);
                if (imageGalleries.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, imageGalleries);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, imageGalleries);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getdesignestimateenquiries")]
        public Response GetDesignEstimateEnquiries([FromQuery] UserDesignEstimation userDesignEstimation)
        {
            Response response = new Response();
            try
            {
                List<UserEstimationEnquiriesGet> userEstimationEnquiriesGet = new GeneralUserEnquiryEstimationsRepository().GetUserEstimationEnquiries(_db, userDesignEstimation);
                if (userEstimationEnquiriesGet.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, userEstimationEnquiriesGet);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, userEstimationEnquiriesGet);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getuserallestimation")]
        public Response GetUserAllEstimation([FromQuery] UserEstimationEnquiries userEstimationEnquiries)
        {
            Response response = new Response();
            try
            {
                List<UserAllEstimationGet> userAllEstimationGet = new GeneralUserEnquiryEstimationsRepository().GetUserAllEstimation(_db, userEstimationEnquiries);
                if (userAllEstimationGet.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, userAllEstimationGet);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, userAllEstimationGet);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertdesignestimateenquiries")]
        public Response InsertUpdateDesignEstimateEnquiries(UserEstimationEnquiries userEstimationEnquiries)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new GeneralUserEnquiryEstimationsRepository().InsertUpdateUserEstimationEnquiries(_db, userEstimationEnquiries);
                if (rowsAffected > 0)
                {
                    List<UserDesignEstimation> userDesignEstimation = new List<UserDesignEstimation>();
                    UserDesignEstimation userDesignEstimation1 = new UserDesignEstimation();
                    userDesignEstimation1.UserDesignEstimationID = rowsAffected;
                    userDesignEstimation.Add(userDesignEstimation1);
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, userDesignEstimation);
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

        [HttpGet]
        [Route("getdesignestimateenquiriesformaterialsetup")]
        public Response GetDesignEstimateEnquiriesForMaterialSetup([FromQuery] UserEstimationEnquiriesForMaterialSetup userEstimationEnquiriesForMaterialSetup)
        {
            Response response = new Response();
            try
            {
                List<UserEstimationEnquiriesForMaterialSetup> UserEstimationEnquiriesForMaterialSetups = new GeneralUserEnquiryEstimationsRepository().GetUserEstimationEnquiriesForMaterialSetup(_db, userEstimationEnquiriesForMaterialSetup);
                if (UserEstimationEnquiriesForMaterialSetups.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, UserEstimationEnquiriesForMaterialSetups);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, UserEstimationEnquiriesForMaterialSetups);
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
