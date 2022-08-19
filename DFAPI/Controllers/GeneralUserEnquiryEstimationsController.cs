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
        #endregion
    }
}
